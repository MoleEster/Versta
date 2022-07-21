using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using VerstaTest.Options.Options;
using VerstaTest.Options.Validation;

namespace VerstaTest.Options.Extensions
{
    public static class OptionsRegistrationExtension
    {

        public static IServiceCollection RegisterOptions(this IServiceCollection services, IConfiguration config)
        {
            services.AddSingleton<IValidateOptions<PostgresOptions>, PostgresOptionsValidator>();

            services.Configure<PostgresOptions>(config.GetSection(PostgresOptions.SectionName));

            return services;
        }
    }
}
