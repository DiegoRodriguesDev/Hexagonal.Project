using Hexagonal.Project.Domain.Models.V1;

namespace Hexagonal.Project.Domain.Services
{
    public interface IProdutoService
    {
        public Task<Produto> ObterProduto(int produtoId);
    }
}
