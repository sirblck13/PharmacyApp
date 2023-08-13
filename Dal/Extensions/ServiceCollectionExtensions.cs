using Dal.Interfaces;
using Dal.Repositories;
using Dal.UnitsOfWork;
using Infrastructure.Dal.Interfaces.UnitOfWork;
using Microsoft.Extensions.DependencyInjection;

namespace Dal.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddDalServices(this IServiceCollection services)
        {

            #region Repositories

            services.AddTransient<IPharmacyRepository, PharmacyRepository>();

            #endregion

            #region UnitsOfWork

            services.AddTransient<IPharmacyUow, PharmacyUow>();

            #endregion
        }
    }
}
