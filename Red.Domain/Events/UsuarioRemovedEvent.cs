using System;
using Red.Domain.Core.Events;

namespace Red.Domain.Events
{
    public class UsuarioRemovedEvent : Event
    {
        public UsuarioRemovedEvent(Guid id)
        {
            Id = id;
            AggregateId = id;
        }

        public Guid Id { get; set; }
    }
}