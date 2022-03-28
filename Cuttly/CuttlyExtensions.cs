using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Cuttly
{
    public static class CuttlyExtensions
    {
        public static void AddCuttly(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<CuttlyOptions>(configuration);
        }

        public static void AddCuttly(this IServiceCollection services, Action<CuttlyOptions> options)
        {
            services.Configure(options);
        }
    }
}
