using Hexagonal.Project.Domain.Exceptions;
using Hexagonal.Project.Domain.Services;
using Hexagonal.Project.WebApi.V1.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace Hexagonal.Project.WebApi.V1.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoService _produtoService;
        
        public ProdutoController(IProdutoService produtoService)
        {
            _produtoService = produtoService;
        }

        [HttpGet]
        public async Task<IActionResult> ObterProdutos(int produtoId)
        {
            var response = new ObterProdutoResponse();
            try
            {
                response.EstruturaRetorno = await _produtoService.ObterProduto(produtoId);
                return Ok(response);
            }
            catch(EstruturaErroException ex)
            {
                response.EstruturaErro = ex.EstruturaErro;
                return BadRequest(response);
            }
            catch(Exception ex)
            {
                response.EstruturaErro = new EstruturaErroFactory().ObterEstruturaErroNaoTratado(ex.Message).EstruturaErro;
                return BadRequest(response);
            }
        }

    }
}
