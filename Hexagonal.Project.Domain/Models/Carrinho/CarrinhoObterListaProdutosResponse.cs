using Hexagonal.Project.Domain.Exceptions;
using Hexagonal.Project.Domain.Models.V1;

namespace Hexagonal.Project.Domain.Models.Carrinho
{
    public class CarrinhoObterListaProdutosResponse
    {
        public List<Produto> Produtos { get; set; }
        public EstruturaErro EstruturaErro { get; set; }

        public CarrinhoObterListaProdutosResponse()
        {
            Produtos = new List<Produto>();
            EstruturaErro = new EstruturaErro();
        }
    }
}
