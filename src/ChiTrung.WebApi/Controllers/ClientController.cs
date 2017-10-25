using System;
using ChiTrung.Application.Interfaces;
using ChiTrung.Application.ViewModels;
using ChiTrung.Domain.Core.Notifications;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ChiTrung.WebApi.Controllers
{
    [Authorize]
    public class ClientController : ApiController
    {
        private readonly IClientAppService _clientAppService;

        public ClientController(IClientAppService clientAppService,
                                  INotificationHandler<DomainNotification> notifications) : base(notifications)
        {
            _clientAppService = clientAppService;
        }

        [HttpGet]
        [AllowAnonymous]
        [Authorize("read:messages")]
        [Route("Client-management/{name}")]
        public IActionResult Get(string name)
        {
            return Response(_clientAppService.GetClientByName(name));
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("Client-management/{id:int}")]
        public IActionResult Get(int id)
        {
            var clientViewModel = _clientAppService.GetClientById(id);

            return Response(clientViewModel);
        }     

        [HttpPost]
        [Authorize("create:messages")]
        [Route("Client-management")]
        public IActionResult Post([FromBody]ClientViewModel clientViewModel)
        {
            if (!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                return Response(clientViewModel);
            }

            //_clientAppService.Register(ClientViewModel);

            return Response(clientViewModel);
        }
        
    }
}
