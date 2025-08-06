using FluentValidation;
using Main.Application.DTO.Request;

namespace Main.Application.Validator
{

    public class ProgramDto_Insert_Validator : AbstractValidator<RequestDtoProgram_Insert>
    {

        public ProgramDto_Insert_Validator()
        {

            RuleFor(u => u.Code).NotNull().NotEmpty().WithMessage("No ha indicado el Codigo.");
            RuleFor(u => u.Name).NotNull().NotEmpty().WithMessage("No ha indicado el Nombre.");
            RuleFor(u => u.Description).NotNull().NotEmpty().WithMessage("No ha indicado la Descripcion.");
            RuleFor(u => u.Order).NotNull().NotEmpty().WithMessage("No ha indicado el Orden.");
            RuleFor(u => u.PathProgram).NotNull().NotEmpty().WithMessage("No ha indicado el Path del Programa.");
            RuleFor(u => u.PathImage).NotNull().NotEmpty().WithMessage("No ha indicado el Path de la Imagen.");
            RuleFor(u => u.CreatedDate).NotNull().NotEmpty().WithMessage("No ha indicado la fecha de creación.");
            RuleFor(u => u.CreatedBy).NotNull().NotEmpty().WithMessage("No ha indicado el usuario que creó el registro.");

        }

    }

    public class ProgramDto_Update_Validator : AbstractValidator<RequestDtoProgram_Update>
    {

        public ProgramDto_Update_Validator()
        {

            RuleFor(u => u.Code).NotNull().NotEmpty().WithMessage("No ha indicado el Codigo.");
            RuleFor(u => u.Name).NotNull().NotEmpty().WithMessage("No ha indicado el Nombre.");
            RuleFor(u => u.Description).NotNull().NotEmpty().WithMessage("No ha indicado la Descripcion.");
            RuleFor(u => u.Order).NotNull().NotEmpty().WithMessage("No ha indicado el Orden.");
            RuleFor(u => u.PathProgram).NotNull().NotEmpty().WithMessage("No ha indicado el Path del Programa.");
            RuleFor(u => u.PathImage).NotNull().NotEmpty().WithMessage("No ha indicado el Path de la Imagen.");
            RuleFor(u => u.LastModifiedDate).NotNull().NotEmpty().WithMessage("No ha indicado la fecha de modificación.");
            RuleFor(u => u.LastModifiedBy).NotNull().NotEmpty().WithMessage("No ha indicado el usuario que modificó el registro.");
        }

    }

    public class ProgramDto_Delete_Validator : AbstractValidator<RequestDtoProgram_Delete>
    {

        public ProgramDto_Delete_Validator()
        {
            RuleFor(u => u.Code).NotNull().NotEmpty().WithMessage("No ha indicado el Codigo.");
        }

    }

    public class ProgramDto_GetById_Validator : AbstractValidator<RequestDtoProgram_GetById>
    {

        public ProgramDto_GetById_Validator()
        {
            RuleFor(u => u.Code).NotNull().NotEmpty().WithMessage("No ha indicado el Codigo.");
        }

    }

    public class ProgramDto_GetByGroupMenu_Validator : AbstractValidator<RequestDtoProgram_GetByGroupMenu>
    {

        public ProgramDto_GetByGroupMenu_Validator()
        {
            RuleFor(u => u.CodeGroupMenu).NotNull().NotEmpty().WithMessage("No ha indicado el Codigo de GroupMenu.");
        }

    }

    public class ProgramDto_GetByMenu_Validator : AbstractValidator<RequestDtoProgram_GetByMenu>
    {

        public ProgramDto_GetByMenu_Validator()
        {
            RuleFor(u => u.CodeMenu).NotNull().NotEmpty().WithMessage("No ha indicado el Codigo de Menu.");
        }

    }

    public class ProgramDto_ListWithPagination_Validator : AbstractValidator<RequestDtoProgram_ListWithPagination>
    {

        public ProgramDto_ListWithPagination_Validator()
        {
            RuleFor(u => u.PageNumber).NotNull().NotEmpty().WithMessage("No ha indicado el número de página.");
            RuleFor(u => u.PageSize).NotNull().NotEmpty().WithMessage("No ha indicado el tamaño de página.");
        }

    }

}
