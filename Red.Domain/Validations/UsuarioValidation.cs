using System;
using Red.Domain.Commands;
using FluentValidation;

namespace Red.Domain.Validations
{
    public abstract class UsuarioValidation<T> : AbstractValidator<T> where T : UsuarioCommand
    {
        protected void ValidateName()
        {
            RuleFor(c => c.Nome)
                .NotEmpty().WithMessage("Please ensure you have entered the Name")
                .Length(2, 150).WithMessage("The Name must have between 2 and 150 characters");
        }

        protected void ValidateSizePassword()
        {
            RuleFor(c => c.Senha)
                .NotEmpty()
                .Must(HaveMinimumPass)
                .WithMessage("A senha deve conter no mínimo 6 caracteres!");
        }

        protected void ValidateEmail()
        {
            RuleFor(c => c.Email)
                .NotEmpty()
                .EmailAddress();
        }

        protected void ValidateId()
        {
            RuleFor(c => c.Id)
                .NotEqual(Guid.Empty);
        }

        protected static bool HaveMinimumPass(string senha)
        {
            return senha.Length >= 6;
        }
    }
}