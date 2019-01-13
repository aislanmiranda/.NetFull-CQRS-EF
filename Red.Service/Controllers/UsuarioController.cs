using System;
using System.Collections.Generic;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Red.Domain.Commands;
using Red.Domain.Core.Bus;
using Red.Domain.Core.Notifications;
using Red.Domain.Interfaces;
using Red.Service.ViewModels;

namespace Red.Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : BaseApiController
    {
        private readonly IMapper _mapper;
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IMediatorHandler _bus;

        public UsuarioController(
            IMapper mapper,
            IUsuarioRepository usuarioRepository,
            IMediatorHandler bus,

            INotificationHandler<DomainNotification> notifications,
            IMediatorHandler mediator) : base(notifications, mediator)
        {
            _mapper = mapper;
            _usuarioRepository = usuarioRepository;
            _bus = bus;
        }

        [HttpGet]
        [Route("listar")]
        public IActionResult Get()
        {
            var lista = _mapper.Map<IEnumerable<UsuarioViewModel>>(_usuarioRepository.GetAll());

            return Response(lista);
        }

        [HttpGet]
        [Route("usuario/{id:guid}")]
        public IActionResult Get(Guid id)
        {
            var usuarioViewModel = _mapper.Map<UsuarioViewModel>(_usuarioRepository.GetById(id));

            return Response(usuarioViewModel);
        }

        [HttpPost]
        [Route("usuario")]
        public IActionResult Post([FromBody]UsuarioViewModel usuarioViewModel)
        {
            if (!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                return Response(usuarioViewModel);
            }

            var registerCommand = _mapper.Map<RegisterNewUsuarioCommand>(usuarioViewModel);
            _bus.SendCommand(registerCommand);

            return Response(usuarioViewModel);
        }

        [HttpPut]
        [Route("usuario")]
        public IActionResult Put([FromBody]UsuarioViewModel usuarioViewModel)
        {
            if (!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                return Response(usuarioViewModel);
            }

            var updateCommand = _mapper.Map<UpdateUsuarioCommand>(usuarioViewModel);
            _bus.SendCommand(updateCommand);

            return Response(usuarioViewModel);
        }

        [HttpDelete]
        [Route("usuario")]
        public IActionResult Delete(Guid id)
        {
            var removeCommand = new RemoveUsuarioCommand(id);
            _bus.SendCommand(removeCommand);

            return Response();
        }

    }
}
