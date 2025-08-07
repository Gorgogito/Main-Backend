using FluentValidation;
using Main.Application.DTO.Request;

namespace Main.Application.Validator
{

    public class ResourceDto_Insert_Validator : AbstractValidator<RequestDtoResource_Insert>
    {

        public ResourceDto_Insert_Validator()
        {

            RuleFor(u => u.Code).NotNull().NotEmpty().WithMessage("No ha indicado el Codigo.");
            RuleFor(u => u.Name).NotNull().NotEmpty().WithMessage("No ha indicado el Nombre.");
            RuleFor(u => u.Description).NotNull().NotEmpty().WithMessage("No ha indicado la Descripcion.");
            RuleFor(u => u.CreatedDate).NotNull().NotEmpty().WithMessage("No ha indicado la fecha de creación.");
            RuleFor(u => u.CreatedBy).NotNull().NotEmpty().WithMessage("No ha indicado el usuario que creó el registro.");

        }

    }

    public class ResourceDto_Update_Validator : AbstractValidator<RequestDtoResource_Update>
    {

        public ResourceDto_Update_Validator()
        {

            RuleFor(u => u.Code).NotNull().NotEmpty().WithMessage("No ha indicado el Codigo.");
            RuleFor(u => u.Name).NotNull().NotEmpty().WithMessage("No ha indicado el Nombre.");
            RuleFor(u => u.Description).NotNull().NotEmpty().WithMessage("No ha indicado la Descripcion.");
            RuleFor(u => u.LastModifiedDate).NotNull().NotEmpty().WithMessage("No ha indicado la fecha de modificación.");
            RuleFor(u => u.LastModifiedBy).NotNull().NotEmpty().WithMessage("No ha indicado el usuario que modificó el registro.");
        }

    }

    public class ResourceDto_Delete_Validator : AbstractValidator<RequestDtoResource_Delete>
    {

        public ResourceDto_Delete_Validator()
        {
            RuleFor(u => u.Code).NotNull().NotEmpty().WithMessage("No ha indicado el Codigo.");
        }

    }

    public class ResourceDto_GetById_Validator : AbstractValidator<RequestDtoResource_GetById>
    {

        public ResourceDto_GetById_Validator()
        {
            RuleFor(u => u.Code).NotNull().NotEmpty().WithMessage("No ha indicado el Codigo.");
        }

    }

    public class ResourceDto_ListWithPagination_Validator : AbstractValidator<RequestDtoResource_ListWithPagination>
    {

        public ResourceDto_ListWithPagination_Validator()
        {
            RuleFor(u => u.PageNumber).NotNull().NotEmpty().WithMessage("No ha indicado el número de página.");
            RuleFor(u => u.PageSize).NotNull().NotEmpty().WithMessage("No ha indicado el tamaño de página.");
        }

    }

}