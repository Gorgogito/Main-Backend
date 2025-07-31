using FluentValidation;
using Main.Application.DTO.Request;

namespace Main.Application.Validator
{

    public class AccessControlDto_Insert_Validator : AbstractValidator<RequestDtoAccessControl_Insert>
    {

        public AccessControlDto_Insert_Validator()
        {

            RuleFor(u => u.Code).NotNull().NotEmpty().WithMessage("No ha indicado el Codigo.");
            RuleFor(u => u.CodeResource).NotNull().NotEmpty().WithMessage("No ha indicado el Codigo de Resource.");
            RuleFor(u => u.CodeProgram).NotNull().NotEmpty().WithMessage("No ha indicado la Codigo de Program.");
            RuleFor(u => u.Read).NotNull().NotEmpty().WithMessage("No ha indicado el valor de Read.");
            RuleFor(u => u.Write).NotNull().NotEmpty().WithMessage("No ha indicado el valor de Write.");
            RuleFor(u => u.Create).NotNull().NotEmpty().WithMessage("No ha indicado el valor de Create.");
            RuleFor(u => u.Eliminate).NotNull().NotEmpty().WithMessage("No ha indicado el valor de Eliminate.");
            RuleFor(u => u.CreatedDate).NotNull().NotEmpty().WithMessage("No ha indicado la fecha de creación.");
            RuleFor(u => u.CreatedBy).NotNull().NotEmpty().WithMessage("No ha indicado el usuario que creó el registro.");

        }

    }

    public class AccessControlDto_Update_Validator : AbstractValidator<RequestDtoAccessControl_Update>
    {

        public AccessControlDto_Update_Validator()
        {

            RuleFor(u => u.Code).NotNull().NotEmpty().WithMessage("No ha indicado el Codigo.");
            RuleFor(u => u.CodeResource).NotNull().NotEmpty().WithMessage("No ha indicado el Codigo de Resource.");
            RuleFor(u => u.CodeProgram).NotNull().NotEmpty().WithMessage("No ha indicado la Codigo de Program.");
            RuleFor(u => u.Read).NotNull().NotEmpty().WithMessage("No ha indicado el valor de Read.");
            RuleFor(u => u.Write).NotNull().NotEmpty().WithMessage("No ha indicado el valor de Write.");
            RuleFor(u => u.Create).NotNull().NotEmpty().WithMessage("No ha indicado el valor de Create.");
            RuleFor(u => u.Eliminate).NotNull().NotEmpty().WithMessage("No ha indicado el valor de Eliminate.");
            RuleFor(u => u.LastModifiedDate).NotNull().NotEmpty().WithMessage("No ha indicado la fecha de modificación.");
            RuleFor(u => u.LastModifiedBy).NotNull().NotEmpty().WithMessage("No ha indicado el usuario que modificó el registro.");
        }

    }

    public class AccessControlDto_Delete_Validator : AbstractValidator<RequestDtoAccessControl_Delete>
    {

        public AccessControlDto_Delete_Validator()
        {
            RuleFor(u => u.Code).NotNull().NotEmpty().WithMessage("No ha indicado el Codigo.");
        }

    }

    public class AccessControlDto_GetById_Validator : AbstractValidator<RequestDtoAccessControl_GetById>
    {

        public AccessControlDto_GetById_Validator()
        {
            RuleFor(u => u.Code).NotNull().NotEmpty().WithMessage("No ha indicado el Codigo.");
        }

    }

    public class AccessControlDto_GetByResource_Validator : AbstractValidator<RequestDtoAccessControl_GetByResource>
    {

        public AccessControlDto_GetByResource_Validator()
        {
            RuleFor(u => u.CodeResource).NotNull().NotEmpty().WithMessage("No ha indicado el Codigo de Resource.");
        }

    }

    public class AccessControlDto_GetByProgram_Validator : AbstractValidator<RequestDtoAccessControl_GetByProgram>
    {

        public AccessControlDto_GetByProgram_Validator()
        {
            RuleFor(u => u.CodeProgram).NotNull().NotEmpty().WithMessage("No ha indicado la Codigo de Program.");
        }

    }

    public class AccessControlDto_ListWithPagination_Validator : AbstractValidator<RequestDtoAccessControl_ListWithPagination>
    {

        public AccessControlDto_ListWithPagination_Validator()
        {
            RuleFor(u => u.PageNumber).NotNull().NotEmpty().WithMessage("No ha indicado el número de página.");
            RuleFor(u => u.PageSize).NotNull().NotEmpty().WithMessage("No ha indicado el tamaño de página.");
        }

    }

}
