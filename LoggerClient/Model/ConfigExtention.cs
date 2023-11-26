using Microsoft.Extensions.Configuration;

namespace LoggerClient.Model
{
    public static class ConfigExtention
    {
        public static IConfiguration Configuration;
        public static void Initialize(IConfiguration configuration)
        {
            Configuration = configuration;

        }
    }
}
