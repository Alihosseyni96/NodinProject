using Domain.IRepositories;
using Infrastructure.Data.Repositories;

namespace NodinAPI.Common.Extensions
{
    public static class DependencyInjectionExtensions
    {
        public static void Register(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();

        }
    }
}
