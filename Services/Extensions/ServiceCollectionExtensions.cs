using Infrastructure.Interfaces.Managers;
using Microsoft.Extensions.DependencyInjection;
using Services.Managers;

namespace Services.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddPharmacyServices(this IServiceCollection services)
        {
            services.AddTransient<IPharmacyManager, PharmacyManager>();
        }
    }
}
