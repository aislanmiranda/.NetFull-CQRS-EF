using Red.Domain.Commands;

namespace Red.Domain.Validations
{
    public class RegisterNewUsuarioCommandValidation : UsuarioValidation<RegisterNewUsuarioCommand>
    {
        public RegisterNewUsuarioCommandValidation()
        {
            ValidateName();
            ValidateSizePassword();
            ValidateEmail();
        }
    }
}