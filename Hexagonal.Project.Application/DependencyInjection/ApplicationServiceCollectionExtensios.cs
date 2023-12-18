using Hexagonal.Project.Application.Services;
using Hexagonal.Project.Domain.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Hexagonal.Project.Application.DependencyInjection
{
    public static class ApplicationServiceCollectionExtensios
    {

        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            services.AddScoped<IProdutoService, ProdutoService>();

            return services;
        }
    }
}
