using FluentValidation;
using Main.Application.DTO.Response;

namespace Main.Application.Validator
{
    public class AuthenticateDtoValidator : AbstractValidator<ResponseDtoAuthenticate>
    {

        public AuthenticateDtoValidator()
        {
            RuleFor(u => u.UserName).NotNull().NotEmpty().WithMessage("No ha indicado el nombre de usuario.");
            RuleFor(u => u.Password).NotNull().NotEmpty().WithMessage("No ha indicado el password de usuario.");
        }

    }
}