using System;
using Red.Domain.Validations;

namespace Red.Domain.Commands
{
    public class RegisterNewUsuarioCommand : UsuarioCommand
    {
        public RegisterNewUsuarioCommand(string nome, string email, string senha)
        {
            Nome = nome;
            Email = email;
            Senha = senha;
        }

        public override bool IsValid()
        {
            ValidationResult = new RegisterNewUsuarioCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}