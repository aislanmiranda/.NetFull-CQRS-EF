using System;
using Red.Domain.Validations;

namespace Red.Domain.Commands
{
    public class UpdateUsuarioCommand : UsuarioCommand
    {
        public UpdateUsuarioCommand(Guid id, string nome, string email, string senha)
        {
            Id = id;
            Nome = nome;
            Email = email;
            Senha = senha;
        }

        public override bool IsValid()
        {
            ValidationResult = new UpdateUsuarioCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}