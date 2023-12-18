using Hexagonal.Project.Domain.Exceptions;
using Hexagonal.Project.Domain.Models.V1;

namespace Hexagonal.Project.WebApi.V1.DTOs
{
    public class ObterProdutoResponse: BaseResponse
    {
        public Produto? EstruturaRetorno { get; set; }

        public ObterProdutoResponse()
        {
            EstruturaErro = new EstruturaErro();
        }
    }
}
