using FluentValidation;
using Main.Application.DTO.Request;

namespace Main.Application.Validator
{
   
    public class GroupMenuDto_Insert_Validator : AbstractValidator<RequestDtoGroupMenu_Insert>
    {

        public GroupMenuDto_Insert_Validator()
        {

            RuleFor(u => u.Code).NotNull().NotEmpty().WithMessage("No ha indicado el Codigo.");
            RuleFor(u => u.Name).NotNull().NotEmpty().WithMessage("No ha indicado el Nombre.");
            RuleFor(u => u.Description).NotNull().NotEmpty().WithMessage("No ha indicado la Descripcion.");
            RuleFor(u => u.Order).NotNull().NotEmpty().WithMessage("No ha indicado el valor de Order.");
            RuleFor(u => u.CreatedDate).NotNull().NotEmpty().WithMessage("No ha indicado la fecha de creación.");
            RuleFor(u => u.CreatedBy).NotNull().NotEmpty().WithMessage("No ha indicado el usuario que creó el registro.");

        }

    }

    public class GroupMenuDto_Update_Validator : AbstractValidator<RequestDtoGroupMenu_Update>
    {

        public GroupMenuDto_Update_Validator()
        {

            RuleFor(u => u.Code).NotNull().NotEmpty().WithMessage("No ha indicado el Codigo.");
            RuleFor(u => u.Name).NotNull().NotEmpty().WithMessage("No ha indicado el Nombre.");
            RuleFor(u => u.Description).NotNull().NotEmpty().WithMessage("No ha indicado la Descripcion.");
            RuleFor(u => u.Order).NotNull().NotEmpty().WithMessage("No ha indicado el valor de Order.");
            RuleFor(u => u.LastModifiedDate).NotNull().NotEmpty().WithMessage("No ha indicado la fecha de modificación.");
            RuleFor(u => u.LastModifiedBy).NotNull().NotEmpty().WithMessage("No ha indicado el usuario que modificó el registro.");
        }

    }

    public class GroupMenuDto_Delete_Validator : AbstractValidator<RequestDtoGroupMenu_Delete>
    {

        public GroupMenuDto_Delete_Validator()
        {
            RuleFor(u => u.Code).NotNull().NotEmpty().WithMessage("No ha indicado el Codigo.");
        }

    }

    public class GroupMenuDto_GetById_Validator : AbstractValidator<RequestDtoGroupMenu_GetById>
    {

        public GroupMenuDto_GetById_Validator()
        {
            RuleFor(u => u.Code).NotNull().NotEmpty().WithMessage("No ha indicado el Codigo.");
        }

    }

    public class GroupMenuDto_ListWithPagination_Validator : AbstractValidator<RequestDtoGroupMenu_ListWithPagination>
    {

        public GroupMenuDto_ListWithPagination_Validator()
        {
            RuleFor(u => u.PageNumber).NotNull().NotEmpty().WithMessage("No ha indicado el número de página.");
            RuleFor(u => u.PageSize).NotNull().NotEmpty().WithMessage("No ha indicado el tamaño de página.");
        }

    }

}
