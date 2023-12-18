using System.ComponentModel.DataAnnotations;

namespace Hexagonal.Project.DbRepository.DependencyInjection
{
    public class DbRepositoryAdapterConfiguration
    {
        [Required]
        public string SqlConnectionString { get; set; }
    }
}
