using FluentValidation;
using Main.Application.DTO.Request;

namespace Main.Application.Validator
{

    public class AdministrationDto_Insert_Validator : AbstractValidator<RequestDtoAdministration_Insert>
    {

        public AdministrationDto_Insert_Validator()
        {
            RuleFor(u => u.CodeResource).NotNull().NotEmpty().WithMessage("No ha indicado el Codigo de Resource.");
            RuleFor(u => u.CodeRole).NotNull().NotEmpty().WithMessage("No ha indicado la Codigo de Rol.");            
            RuleFor(u => u.CreatedDate).NotNull().NotEmpty().WithMessage("No ha indicado la fecha de creación.");
            RuleFor(u => u.CreatedBy).NotNull().NotEmpty().WithMessage("No ha indicado el usuario que creó el registro.");
        }

    }

    public class AdministrationDto_Update_Validator : AbstractValidator<RequestDtoAdministration_Update>
    {
        public AdministrationDto_Update_Validator()
        {            
            RuleFor(u => u.CodeResource).NotNull().NotEmpty().WithMessage("No ha indicado el Codigo de Resource.");
            RuleFor(u => u.CodeRole).NotNull().NotEmpty().WithMessage("No ha indicado la Codigo de Rol.");            
            RuleFor(u => u.LastModifiedDate).NotNull().NotEmpty().WithMessage("No ha indicado la fecha de modificación.");
            RuleFor(u => u.LastModifiedBy).NotNull().NotEmpty().WithMessage("No ha indicado el usuario que modificó el registro.");
        }
    }

    public class AdministrationDto_Delete_Validator : AbstractValidator<RequestDtoAdministration_Delete>
    {

        public AdministrationDto_Delete_Validator()
        {
            RuleFor(u => u.CodeRole).NotNull().NotEmpty().WithMessage("No ha indicado el Codigo de Rol.");
            RuleFor(u => u.CodeResource).NotNull().NotEmpty().WithMessage("No ha indicado el Codigo de Recurso.");
        }

    }

    public class AdministrationDto_GetById_Validator : AbstractValidator<RequestDtoAdministration_GetById>
    {

        public AdministrationDto_GetById_Validator()
        {
            RuleFor(u => u.CodeRole).NotNull().NotEmpty().WithMessage("No ha indicado el Codigo de Rol.");
            RuleFor(u => u.CodeResource).NotNull().NotEmpty().WithMessage("No ha indicado el Codigo de Recurso.");
        }

    }

    public class AdministrationDto_GetByResource_Validator : AbstractValidator<RequestDtoAdministration_GetByResource>
    {

        public AdministrationDto_GetByResource_Validator()
        {
            RuleFor(u => u.CodeResource).NotNull().NotEmpty().WithMessage("No ha indicado el Codigo de Resource.");
        }

    }

    public class AdministrationDto_GetByRole_Validator : AbstractValidator<RequestDtoAdministration_GetByRole>
    {

        public AdministrationDto_GetByRole_Validator()
        {
            RuleFor(u => u.CodeRole).NotNull().NotEmpty().WithMessage("No ha indicado la Codigo de Rol.");
        }

    }

    public class AdministrationDto_ListWithPagination_Validator : AbstractValidator<RequestDtoAdministration_ListWithPagination>
    {

        public AdministrationDto_ListWithPagination_Validator()
        {
            RuleFor(u => u.PageNumber).NotNull().NotEmpty().WithMessage("No ha indicado el número de página.");
            RuleFor(u => u.PageSize).NotNull().NotEmpty().WithMessage("No ha indicado el tamaño de página.");
        }

    }

}
