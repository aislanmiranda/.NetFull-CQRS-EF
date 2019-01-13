using Red.Domain.Core.Models;
using System;

namespace Red.Domain.Models
{
    public class Usuario : Entity
    {

        public Usuario(Guid id, string nome, string email, string senha)
        {
            Id = id;
            Nome = nome;
            Email = email;
            Senha = senha;
        }

        // Empty constructor for EF
        protected Usuario() { }

        public string Nome { get; private set; }

        public string Email { get; private set; }

        public string Senha { get; private set; }

    }
}