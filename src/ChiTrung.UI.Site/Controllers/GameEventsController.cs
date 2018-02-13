using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChiTrung.Application.Interfaces;
using ChiTrung.Domain.Core.Notifications;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ChiTrung.UI.Site.Controllers
{
    public class GameEventsController : BaseController
    {
        private readonly IGameEventsService _gameEventsService;

        public GameEventsController(IGameEventsService gameEventsService,                                    
                                    INotificationHandler<DomainNotification> notifications) : base(notifications)
        {
            _gameEventsService = gameEventsService;
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("gameevents-management/list-all")]
        public IActionResult Index()
        {
            return View(_gameEventsService.GetAll());
        }
    }
}