using FluentValidation;
using Main.Application.DTO.Request;

namespace Main.Application.Validator
{

    public class RolePerUserDto_Insert_Validator : AbstractValidator<RequestDtoRolePerUser_Insert>
    {

        public RolePerUserDto_Insert_Validator()
        {

            RuleFor(u => u.UserName).NotNull().NotEmpty().WithMessage("No ha indicado el Usuario.");
            RuleFor(u => u.CodeRole).NotNull().NotEmpty().WithMessage("No ha indicado el Rol.");
            RuleFor(u => u.CreatedDate).NotNull().NotEmpty().WithMessage("No ha indicado la fecha de creación.");
            RuleFor(u => u.CreatedBy).NotNull().NotEmpty().WithMessage("No ha indicado el usuario que creó el registro.");

        }

    }

    public class RolePerUserDto_Delete_Validator : AbstractValidator<RequestDtoRolePerUser_Delete>
    {

        public RolePerUserDto_Delete_Validator()
        {
            RuleFor(u => u.UserName).NotNull().NotEmpty().WithMessage("No ha indicado el Usuario.");
            RuleFor(u => u.CodeRole).NotNull().NotEmpty().WithMessage("No ha indicado el Rol.");
        }

    }

    public class RolePerUserDto_GetById_Validator : AbstractValidator<RequestDtoRolePerUser_GetById>
    {

        public RolePerUserDto_GetById_Validator()
        {
            RuleFor(u => u.UserName).NotNull().NotEmpty().WithMessage("No ha indicado el Usuario.");
            RuleFor(u => u.CodeRole).NotNull().NotEmpty().WithMessage("No ha indicado el Rol.");
        }

    }

    public class RolePerUserDto_GetByUser_Validator : AbstractValidator<RequestDtoRolePerUser_GetByUser>
    {

        public RolePerUserDto_GetByUser_Validator()
        {
            RuleFor(u => u.UserName).NotNull().NotEmpty().WithMessage("No ha indicado el Usuario.");
        }

    }

    public class RolePerUserDto_GetByRole_Validator : AbstractValidator<RequestDtoRolePerUser_GetByRole>
    {

        public RolePerUserDto_GetByRole_Validator()
        {
            RuleFor(u => u.CodeRole).NotNull().NotEmpty().WithMessage("No ha indicado el Rol.");
        }

    }

    public class RolePerUserDto_ListWithPagination_Validator : AbstractValidator<RequestDtoRolePerUser_ListWithPagination>
    {

        public RolePerUserDto_ListWithPagination_Validator()
        {
            RuleFor(u => u.PageNumber).NotNull().NotEmpty().WithMessage("No ha indicado el número de página.");
            RuleFor(u => u.PageSize).NotNull().NotEmpty().WithMessage("No ha indicado el tamaño de página.");
        }

    }

}
