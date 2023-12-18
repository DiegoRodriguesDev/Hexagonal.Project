using Hexagonal.Project.Domain.Models.V1;

namespace Hexagonal.Project.Domain.Adapters.DbRepositories
{
    public interface IProdutoDbRepository
    {
        public Task<Produto> ObterProduto(int produtoId);
    }
}
