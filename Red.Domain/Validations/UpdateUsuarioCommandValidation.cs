using Red.Domain.Commands;

namespace Red.Domain.Validations
{
    public class UpdateUsuarioCommandValidation : UsuarioValidation<UpdateUsuarioCommand>
    {
        public UpdateUsuarioCommandValidation()
        {
            ValidateId();
            ValidateName();
            ValidateSizePassword();
            ValidateEmail();
        }
    }
}