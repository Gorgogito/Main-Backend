using FluentValidation;
using Main.Application.DTO.Request;

namespace Main.Application.Validator
{

    public class MenuDto_Insert_Validator : AbstractValidator<RequestDtoMenu_Insert>
    {

        public MenuDto_Insert_Validator()
        {

            RuleFor(u => u.Code).NotNull().NotEmpty().WithMessage("No ha indicado el Codigo.");
            RuleFor(u => u.Name).NotNull().NotEmpty().WithMessage("No ha indicado el Nombre.");
            RuleFor(u => u.Description).NotNull().NotEmpty().WithMessage("No ha indicado la Descripcion.");
            RuleFor(u => u.Order).NotNull().NotEmpty().WithMessage("No ha indicado el Orden.");
            RuleFor(u => u.Level).NotNull().NotEmpty().WithMessage("No ha indicado el Nivel.");
            RuleFor(u => u.CreatedDate).NotNull().NotEmpty().WithMessage("No ha indicado la fecha de creación.");
            RuleFor(u => u.CreatedBy).NotNull().NotEmpty().WithMessage("No ha indicado el usuario que creó el registro.");

        }

    }

    public class MenuDto_Update_Validator : AbstractValidator<RequestDtoMenu_Update>
    {

        public MenuDto_Update_Validator()
        {

            RuleFor(u => u.Code).NotNull().NotEmpty().WithMessage("No ha indicado el Codigo.");
            RuleFor(u => u.Name).NotNull().NotEmpty().WithMessage("No ha indicado el Nombre.");
            RuleFor(u => u.Description).NotNull().NotEmpty().WithMessage("No ha indicado la Descripcion.");
            RuleFor(u => u.Order).NotNull().NotEmpty().WithMessage("No ha indicado el Orden.");
            RuleFor(u => u.Level).NotNull().NotEmpty().WithMessage("No ha indicado el Nivel.");
            RuleFor(u => u.LastModifiedDate).NotNull().NotEmpty().WithMessage("No ha indicado la fecha de modificación.");
            RuleFor(u => u.LastModifiedBy).NotNull().NotEmpty().WithMessage("No ha indicado el usuario que modificó el registro.");
        }

    }

    public class MenuDto_Delete_Validator : AbstractValidator<RequestDtoMenu_Delete>
    {

        public MenuDto_Delete_Validator()
        {
            RuleFor(u => u.Code).NotNull().NotEmpty().WithMessage("No ha indicado el Codigo.");
        }

    }

    public class MenuDto_GetById_Validator : AbstractValidator<RequestDtoMenu_GetById>
    {

        public MenuDto_GetById_Validator()
        {
            RuleFor(u => u.Code).NotNull().NotEmpty().WithMessage("No ha indicado el Codigo.");
        }

    }

    public class MenuDto_GetByGroupMenu_Validator : AbstractValidator<RequestDtoMenu_GetByGroupMenu>
    {

        public MenuDto_GetByGroupMenu_Validator()
        {
            RuleFor(u => u.CodeGroupMenu).NotNull().NotEmpty().WithMessage("No ha indicado el Codigo de GroupMenu.");
        }

    }

    public class MenuDto_ListWithPagination_Validator : AbstractValidator<RequestDtoMenu_ListWithPagination>
    {

        public MenuDto_ListWithPagination_Validator()
        {
            RuleFor(u => u.PageNumber).NotNull().NotEmpty().WithMessage("No ha indicado el número de página.");
            RuleFor(u => u.PageSize).NotNull().NotEmpty().WithMessage("No ha indicado el tamaño de página.");
        }

    }

}