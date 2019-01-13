using Red.Domain.Commands;

namespace Red.Domain.Validations
{
    public class RemoveUsuarioCommandValidation : UsuarioValidation<RemoveUsuarioCommand>
    {
        public RemoveUsuarioCommandValidation()
        {
            ValidateId();
        }
    }
}