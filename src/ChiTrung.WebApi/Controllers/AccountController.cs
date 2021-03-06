﻿using System.Security.Claims;
using System.Threading.Tasks;
using ChiTrung.Domain.Core.Notifications;
using ChiTrung.Infra.CrossCutting.Identity.Models;
using ChiTrung.Infra.CrossCutting.Identity.Models.AccountViewModels;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ChiTrung.WebApi.Controllers
{
    [Authorize]
    public class AccountController : ApiController
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ILogger _logger;

        public AccountController(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            INotificationHandler<DomainNotification> notifications,
            ILoggerFactory loggerFactory) : base(notifications)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = loggerFactory.CreateLogger<AccountController>();
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("account")]
        public async Task<IActionResult> Login([FromBody] MobileRegisterViewModel model)
        {
            if (!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                return Response(model);
            }

            var result = await _signInManager.PasswordSignInAsync(model.UserName, model.Password, false, true);
            if (!result.Succeeded)
                NotifyError(result.ToString(), "Login failure");

            _logger.LogInformation(1, "User logged in.");

            return Response(model);
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("account/register")]
        public async Task<IActionResult> Register([FromBody] MobileRegisterViewModel model)
        {
            if (!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                return Response(model);
            }

            var user = new ApplicationUser { UserName = model.UserName };

            try
            {
                var result = await _userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    // User claim for write customers data
                    //await _userManager.AddClaimAsync(user, new Claim("Customers", "Write"));

                    // User claim for write employee data
                    //await _userManager.AddClaimAsync(user, new Claim("Employee", "Write"));

                    await _signInManager.SignInAsync(user, false);
                    _logger.LogInformation(3, "User created a new account with password.");
                    return Response(model);
                }

                AddIdentityErrors(result);
            }
            catch (System.Exception ex)
            {
                throw;
            }           

            
            return Response(model);
        }
    }
}
