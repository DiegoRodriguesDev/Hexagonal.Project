using AutoMapper;
using Hexagonal.Project.DbRepository.V1.DTOs;
using Hexagonal.Project.Domain.Models.V1;

namespace Hexagonal.Project.DbRepository.V1.Mappers
{
    public class DbRepositoryAdapterMapperProfile: Profile
    {
        public DbRepositoryAdapterMapperProfile() 
        {
            CreateMap<ProdutoDto, Produto>()
                .ForMember(x => x.Id, x => x.MapFrom(y => y.PRODUTO_ID))
                .ForMember(x => x.Name, x => x.MapFrom(y => y.PRODUTO_NAME))
            ;

        }
    }
}
