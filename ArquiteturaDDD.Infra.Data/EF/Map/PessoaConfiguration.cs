using ArquiteturaDDD.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace ArquiteturaDDD.Infra.Data.EF.Map
{
    public class PessoaConfiguration : EntityTypeConfiguration<Pessoa>
    {
        public PessoaConfiguration()
        {
            //Specific DB Mapping Configurations
        }
    }
}
