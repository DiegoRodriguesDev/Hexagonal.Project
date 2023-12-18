using Hexagonal.Project.Domain.Adapters.HttpClient;
using Hexagonal.Project.HttpClientAdapter.HttpClient;
using Microsoft.Extensions.DependencyInjection;

namespace Hexagonal.Project.HttpClientAdapter.DependencyInjection
{
    public static class HttpClientAdapterServiceCollectionExtensions
    {
        public static IServiceCollection AddHttpClientAdapter(this IServiceCollection service)
        {
            if (service == null) throw new ArgumentNullException(nameof(service));

            service.AddScoped<ICarrinhoHttpClientAdapter, CarrinhoHttpClientAdapter>();

            return service;
        }
    }
}
 