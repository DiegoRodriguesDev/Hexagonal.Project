using AutoMapper;
using Dapper;
using Hexagonal.Project.DbRepository.V1.DTOs;
using Hexagonal.Project.Domain.Adapters.DbRepositories;
using Hexagonal.Project.Domain.Exceptions;
using Hexagonal.Project.Domain.Models.V1;
using System.Data;

namespace Hexagonal.Project.DbRepository.V1.Repositories
{
    public class ProdutoDbRepositoryAdapter : IProdutoDbRepository
    {
        private readonly IDbConnection _dbConnection;
        private readonly IMapper _mapper;

        public ProdutoDbRepositoryAdapter(IDbConnection dbConnection, IMapper mapper)
        {
            _dbConnection = dbConnection;
            _mapper = mapper;
        }
        
        public async Task<Produto> ObterProduto(int produtoId)
        {
            _dbConnection.Open();
            try
            {
                var query = @"
                    SELECT 
                        PRODUTO_ID,
                        PRODUTO_NAME
                    FROM 
                        PRODUTOS
                    WHERE   
                        ID = @ID
                ";

                var parameters = new DynamicParameters();
                parameters.Add("@ID", produtoId);
                var produtoDto = await _dbConnection.QueryFirstOrDefaultAsync<ProdutoDto>(query, parameters);
                var produto = _mapper.Map<Produto>(produtoDto);
                return produto;
            }
            catch (Exception ex)
            {
                throw new EstruturaErroFactory().ObterEstruturaErro(99, $"Erro ao obter resultados na base de dados: {ex.Message}");
            }
        }
    }
}
