using Solutions.Utility.AppLogger;

namespace Main.Service.WebApi.Modules.Logging
{
    public static class LoggingExtensions
    {

        public static IServiceCollection AddLogger(this IServiceCollection services)
        {
            Solutions.Utility.AppLogger.ILogger logging = new Logger();

            logging.AddPath($"C:\\Logs");
            logging.AddFile($"LOG_Main.Service.Api_" + DateTime.Now.ToString("yyyyMMdd") + ".log");
            services.AddSingleton(logging);
            return services;
        }

    }
}
