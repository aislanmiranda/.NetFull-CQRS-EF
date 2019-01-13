using System;
using System.Threading;
using System.Threading.Tasks;
using Red.Domain.Commands;
using Red.Domain.Core.Bus;
using Red.Domain.Core.Notifications;
using Red.Domain.Events;
using Red.Domain.Interfaces;
using Red.Domain.Models;
using MediatR;

namespace Red.Domain.CommandHandlers
{
    public class UsuarioCommandHandler : CommandHandler,
        IRequestHandler<RegisterNewUsuarioCommand>,
        IRequestHandler<UpdateUsuarioCommand>,
        IRequestHandler<RemoveUsuarioCommand>
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IMediatorHandler Bus;

        public UsuarioCommandHandler(IUsuarioRepository UsuarioRepository,
                                      IUnitOfWork uow,
                                      IMediatorHandler bus,
                                      INotificationHandler<DomainNotification> notifications) : base(uow, bus, notifications)
        {
            _usuarioRepository = UsuarioRepository;
            Bus = bus;
        }

        public Task Handle(RegisterNewUsuarioCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid())
            {
                NotifyValidationErrors(message);
                return Task.CompletedTask;
            }

            var Usuario = new Usuario(Guid.NewGuid(), message.Nome, message.Email, message.Senha);

            if (_usuarioRepository.GetByEmail(Usuario.Email) != null)
            {
                Bus.RaiseEvent(new DomainNotification(message.MessageType, "The Usuario e-mail has already been taken."));
                return Task.CompletedTask;
            }

            _usuarioRepository.Add(Usuario);

            if (Commit())
            {
                Bus.RaiseEvent(new UsuarioRegisteredEvent(Usuario.Id, Usuario.Nome, Usuario.Email, Usuario.Senha));
            }

            return Task.CompletedTask;
        }

        public Task Handle(UpdateUsuarioCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid())
            {
                NotifyValidationErrors(message);
                return Task.CompletedTask;
            }

            var Usuario = new Usuario(message.Id, message.Nome, message.Email, message.Senha);
            var existingUsuario = _usuarioRepository.GetByEmail(Usuario.Email);

            if (existingUsuario != null && existingUsuario.Id != Usuario.Id)
            {
                if (!existingUsuario.Equals(Usuario))
                {
                    Bus.RaiseEvent(new DomainNotification(message.MessageType, "The Usuario e-mail has already been taken."));
                    return Task.CompletedTask;
                }
            }

            _usuarioRepository.Update(Usuario);

            if (Commit())
            {
                Bus.RaiseEvent(new UsuarioUpdatedEvent(Usuario.Id, Usuario.Nome, Usuario.Email, Usuario.Senha));
            }

            return Task.CompletedTask;
        }

        public Task Handle(RemoveUsuarioCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid())
            {
                NotifyValidationErrors(message);
                return Task.CompletedTask;
            }

            _usuarioRepository.Remove(message.Id);

            if (Commit())
            {
                Bus.RaiseEvent(new UsuarioRemovedEvent(message.Id));
            }

            return Task.CompletedTask;
        }

        public void Dispose()
        {
            _usuarioRepository.Dispose();
        }
    }
}