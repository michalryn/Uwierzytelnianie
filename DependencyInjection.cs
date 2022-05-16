using Uwierzytelnianie.Interfaces;
using Uwierzytelnianie.Services;
using Uwierzytelnianie.Repositories;

namespace Uwierzytelnianie
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddProjectService(this IServiceCollection services)
        {
            services.AddTransient<IPersonRepository, PersonRepository>();
            services.AddTransient<IPersonService, PersonService>();

            return services;
        }
    }
}
