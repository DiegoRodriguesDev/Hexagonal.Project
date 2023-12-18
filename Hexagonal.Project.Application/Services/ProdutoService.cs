using Hexagonal.Project.Domain.Adapters.DbRepositories;
using Hexagonal.Project.Domain.Adapters.HttpClient;
using Hexagonal.Project.Domain.Exceptions;
using Hexagonal.Project.Domain.Models.V1;
using Hexagonal.Project.Domain.Services;

namespace Hexagonal.Project.Application.Services
{
    public class ProdutoService : IProdutoService
    {
        private readonly IProdutoDbRepository _produtoRepository;
        private readonly ICarrinhoHttpClientAdapter _carrinhoHttpClientAdapter;

        public ProdutoService(IProdutoDbRepository produtoRepository, ICarrinhoHttpClientAdapter carrinhoHttpClientAdapter)
        {
            _produtoRepository = produtoRepository;
            _carrinhoHttpClientAdapter = carrinhoHttpClientAdapter;
        }

        public async Task<Produto> ObterProduto(int produtoId)
        {
            try
            {
                ValidaProduto(produtoId); // Validação parametros de entrada
                var produto = await _produtoRepository.ObterProduto(produtoId); // Comunicação com banco de dados
                var produtos = await _carrinhoHttpClientAdapter.ObterListaProdutos(); // Comunicação com outro serviço
                return produto;
            }
            catch (EstruturaErroException ex)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new EstruturaErroFactory().ObterEstruturaErroNaoTratado(ex.Message);
            }
            
        }

        public void ValidaProduto(int produtoId)
        {
            if (produtoId <= 0)
            {
                throw new EstruturaErroFactory().ObterEstruturaErro(2, "produtoId inválido");
            }
        }
    }
}
