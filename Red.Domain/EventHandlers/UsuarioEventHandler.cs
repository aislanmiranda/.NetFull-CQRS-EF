using System.Threading;
using System.Threading.Tasks;
using Red.Domain.Events;
using MediatR;

namespace Red.Domain.EventHandlers
{
    public class UsuarioEventHandler :
        INotificationHandler<UsuarioRegisteredEvent>,
        INotificationHandler<UsuarioUpdatedEvent>,
        INotificationHandler<UsuarioRemovedEvent>
    {
        public Task Handle(UsuarioUpdatedEvent message, CancellationToken cancellationToken)
        {
            // enviar email por ser usado aqui

            return Task.CompletedTask;
        }

        public Task Handle(UsuarioRegisteredEvent message, CancellationToken cancellationToken)
        {
            // enviar email por ser usado aqui

            return Task.CompletedTask;
        }

        public Task Handle(UsuarioRemovedEvent message, CancellationToken cancellationToken)
        {
            // enviar email por ser usado aqui

            return Task.CompletedTask;
        }
    }
}