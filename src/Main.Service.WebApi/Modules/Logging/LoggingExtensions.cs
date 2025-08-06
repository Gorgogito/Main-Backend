using Solutions.Utility.AppLogger;

namespace Main.Service.WebApi.Modules.Logging
{
    public static class LoggingExtensions
    {

        //private static readonly IConfiguration Configuration;

        public static IServiceCollection AddLogger(this IServiceCollection services, IConfiguration configuration)
        {
            Solutions.Utility.AppLogger.ILogger logging = new Logger();

            var path = configuration["Logger:Path"];
            var file = configuration["Logger:File"];

            logging.AddPath(path!);
            logging.AddFile(file! + DateTime.Now.ToString("yyyyMMdd") + ".log");
            services.AddSingleton(logging);
            return services;
        }

    }
}
