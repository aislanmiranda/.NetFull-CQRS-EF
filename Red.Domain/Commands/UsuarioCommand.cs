using System;
using Red.Domain.Core.Commands;

namespace Red.Domain.Commands
{
    public abstract class UsuarioCommand : Command
    {
        public Guid Id { get; protected set; }

        public string Nome { get; protected set; }

        public string Email { get; protected set; }

        public string Senha { get; protected set; }
    }
}