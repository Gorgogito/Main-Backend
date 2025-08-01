using Main.Application.Validator;

namespace Main.Service.WebApi.Modules.Validator
{
    public static class ValidatorExtensions
    {

        public static IServiceCollection AddValidator(this IServiceCollection services)
        {
            services.AddTransient<AuthenticateDtoValidator>();

            services.AddTransient<UserDto_Insert_Validator>();
            services.AddTransient<UserDto_Update_Validator>();
            services.AddTransient<UserDto_Delete_Validator>();
            services.AddTransient<UserDto_GetById_Validator>();
            services.AddTransient<UserDto_ListWithPagination_Validator>();

            services.AddTransient<AccessControlDto_Insert_Validator>();
            services.AddTransient<AccessControlDto_Update_Validator>();
            services.AddTransient<AccessControlDto_Delete_Validator>();
            services.AddTransient<AccessControlDto_GetById_Validator>();
            services.AddTransient<AccessControlDto_GetByResource_Validator>();
            services.AddTransient<AccessControlDto_GetByProgram_Validator>();
            services.AddTransient<AccessControlDto_ListWithPagination_Validator>();

            services.AddTransient<AdministrationDto_Insert_Validator>();
            services.AddTransient<AdministrationDto_Update_Validator>();
            services.AddTransient<AdministrationDto_Delete_Validator>();
            services.AddTransient<AdministrationDto_GetById_Validator>();
            services.AddTransient<AdministrationDto_GetByResource_Validator>();
            services.AddTransient<AdministrationDto_GetByRole_Validator>();
            services.AddTransient<AdministrationDto_ListWithPagination_Validator>();

            services.AddTransient<GroupMenuDto_Insert_Validator>();
            services.AddTransient<GroupMenuDto_Update_Validator>();
            services.AddTransient<GroupMenuDto_Delete_Validator>();
            services.AddTransient<GroupMenuDto_GetById_Validator>();
            services.AddTransient<GroupMenuDto_ListWithPagination_Validator>();

            return services;
        }

    }
}
