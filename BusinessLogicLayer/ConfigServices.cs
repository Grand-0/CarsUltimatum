using DataAccessLayer.Repository.UnitOfWork;
using Microsoft.Extensions.DependencyInjection;

namespace BusinessLogicLayer
{
    public static class ConfigServices
    {
        public static void BuildConfig(IServiceCollection services, string dbpath)
        {
            services.AddScoped<IUnitOfWork>(o => new UnitOfWork(dbpath));
        }
    }
}
