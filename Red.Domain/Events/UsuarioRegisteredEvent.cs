using System;
using Red.Domain.Core.Events;

namespace Red.Domain.Events
{
    public class UsuarioRegisteredEvent : Event
    {
        public UsuarioRegisteredEvent(Guid id, string nome, string email, string senha)
        {
            Id = id;
            Nome = nome;
            Email = email;
            Senha = senha;
            AggregateId = id;
        }
        public Guid Id { get; set; }

        public string Nome { get; private set; }

        public string Email { get; private set; }

        public string Senha { get; private set; }
    }
}