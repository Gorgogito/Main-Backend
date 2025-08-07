using Main.Application.Interface;
using Main.Application.Main;
using Main.Cross.Common;
using Main.Domain.Core;
using Main.Domain.Interface;
using Main.Infrastructure.Data;
using Main.Infrastructure.Interface;
using Main.Infrastructure.Repository;

namespace Main.Service.WebApi.Modules.Injection
{
    public static class InjectionExtensions
    {

        public static IServiceCollection AddInjection(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<IConfiguration>(configuration);
            services.AddSingleton<IConnectionFactory, ConnectionFactory>();
                        
            services.AddScoped<IAuthenticateApplication, AuthenticateApplication>();
            services.AddScoped<IAuthenticateDomain, AuthenticateDomain>();
            services.AddScoped<IAuthenticateRepository, AuthenticateRepository>();

            services.AddScoped<IUserApplication, UserApplication>();
            services.AddScoped<IUserDomain, UserDomain>();
            services.AddScoped<IUserRepository, UserRepository>();

            services.AddScoped<IEncryptingApplication, EncryptingApplication>();
            services.AddScoped<IEncryptingDomain, EncryptingDomain>();
            services.AddScoped<IEncryptingRepository, EncryptingRepository>();

            services.AddScoped<IAccessControlApplication, AccessControlApplication>();
            services.AddScoped<IAccessControlDomain, AccessControlDomain>();
            services.AddScoped<IAccessControlRepository, AccessControlRepository>();

            services.AddScoped<IAdministrationApplication, AdministrationApplication>();
            services.AddScoped<IAdministrationDomain, AdministrationDomain>();
            services.AddScoped<IAdministrationRepository, AdministrationRepository>();

            services.AddScoped<IGroupMenuApplication, GroupMenuApplication>();
            services.AddScoped<IGroupMenuDomain, GroupMenuDomain>();
            services.AddScoped<IGroupMenuRepository, GroupMenuRepository>();

            services.AddScoped<IMenuApplication, MenuApplication>();
            services.AddScoped<IMenuDomain, MenuDomain>();
            services.AddScoped<IMenuRepository, MenuRepository>();

            services.AddScoped<IProgramApplication, ProgramApplication>();
            services.AddScoped<IProgramDomain, ProgramDomain>();
            services.AddScoped<IProgramRepository, ProgramRepository>();

            services.AddScoped<IResourceApplication, ResourceApplication>();
            services.AddScoped<IResourceDomain, ResourceDomain>();
            services.AddScoped<IResourceRepository, ResourceRepository>();

            services.AddScoped<IRoleApplication, RoleApplication>();
            services.AddScoped<IRoleDomain, RoleDomain>();
            services.AddScoped<IRoleRepository, RoleRepository>();

            //services.AddScoped(typeof(IAppLogger), typeof(LoggerAdapter));

            return services;
        }

    }
}
