using System;
using Red.Domain.Validations;

namespace Red.Domain.Commands
{
    public class RemoveUsuarioCommand : UsuarioCommand
    {
        public RemoveUsuarioCommand(Guid id)
        {
            Id = id;
            AggregateId = id;
        }

        public override bool IsValid()
        {
            ValidationResult = new RemoveUsuarioCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}