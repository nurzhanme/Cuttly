using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Cuttly
{
    public static class CuttlyExtensions
    {
        public static IServiceCollection AddCuttlyClient(this IServiceCollection services)
        {
            services.AddOptions<CuttlyOptions>();
            services.AddHttpClient<CuttlyClient>();
            var configuration = services.BuildServiceProvider().GetRequiredService<IConfiguration>();
            services.Configure<CuttlyOptions>(configuration.GetSection(nameof(CuttlyOptions)));
            return services;
        }

        public static IServiceCollection AddCuttlyClient(this IServiceCollection services, Action<CuttlyOptions> setupAction)
        {
            services.AddOptions<CuttlyOptions>().Configure(setupAction);
            services.AddHttpClient<CuttlyClient>();
            return services;
        }
    }
}
