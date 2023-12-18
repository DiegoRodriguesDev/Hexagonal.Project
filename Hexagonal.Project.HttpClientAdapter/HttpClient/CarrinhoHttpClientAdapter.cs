using Hexagonal.Project.Domain.Adapters.HttpClient;
using Hexagonal.Project.Domain.Exceptions;
using Hexagonal.Project.Domain.Models.Carrinho;
using System.Text.Json;

namespace Hexagonal.Project.HttpClientAdapter.HttpClient
{
    public class CarrinhoHttpClientAdapter : ICarrinhoHttpClientAdapter
    {
        private readonly IHttpClientFactory _httpClientFactory;
        
        public CarrinhoHttpClientAdapter(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        
        public async Task<CarrinhoObterListaProdutosResponse> ObterListaProdutos()
        {
            try
            {
                var client = _httpClientFactory.CreateClient();

                var response = await client.GetAsync("http://url-servico-carrinho/v1/ObterListaProdutos");
                var content = await response.Content.ReadAsStringAsync();
                var estruturaSaida = JsonSerializer.Deserialize<CarrinhoObterListaProdutosResponse>(content);
                
                return estruturaSaida;
            }
            catch (TaskCanceledException ex)
            {
                throw new EstruturaErroFactory().ObterEstruturaErro(3, ex.Message);
            }
            catch (Exception ex)
            {
                throw new EstruturaErroFactory().ObterEstruturaErro(4, ex.Message);
            }
        }
    }
}
