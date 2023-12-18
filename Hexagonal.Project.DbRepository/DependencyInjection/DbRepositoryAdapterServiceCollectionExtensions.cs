using Hexagonal.Project.DbRepository.V1.Repositories;
using Hexagonal.Project.Domain.Adapters.DbRepositories;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.DependencyInjection;
using System.Data;

namespace Hexagonal.Project.DbRepository.DependencyInjection
{
    public static class DbRepositoryAdapterServiceCollectionExtensions
    {
        public static IServiceCollection AddDbRepositoryAdapter(
            this IServiceCollection services, 
            DbRepositoryAdapterConfiguration dbRepositoryAdapterConfiguration)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));
            if (dbRepositoryAdapterConfiguration == null) throw new ArgumentNullException(nameof(dbRepositoryAdapterConfiguration));

            services.AddSingleton<IDbConnection>(x =>
            {
                return new SqlConnection();
                //return new SqlConnection(dbRepositoryAdapterConfiguration.SqlConnectionString);
            });

            services.AddSingleton<IProdutoDbRepository, ProdutoDbRepositoryAdapter>();

            return services;
        }
    }
}
