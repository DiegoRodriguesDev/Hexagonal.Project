using Hexagonal.Project.Domain.Models.Carrinho;

namespace Hexagonal.Project.Domain.Adapters.HttpClient
{
    public interface ICarrinhoHttpClientAdapter
    {
        Task<CarrinhoObterListaProdutosResponse> ObterListaProdutos();
    }
}
