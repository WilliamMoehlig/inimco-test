using DevTest.BL.Infrastructure;
using DevTest.BL.Services;
using DevTest.DAL;
using DevTest.DAL.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace DevTest.API.Extensions
{
    public static class MyModuleExtensions
    {
        public static IServiceCollection AddDevTestModule(this IServiceCollection services)
        {
            services.TryAddSingleton<DevTestContext>();
            services.TryAddScoped<IPersonRepository, PersonRepository>();
            services.TryAddScoped<IPersonService, PersonService>();

            return services;
        }
    }
}
