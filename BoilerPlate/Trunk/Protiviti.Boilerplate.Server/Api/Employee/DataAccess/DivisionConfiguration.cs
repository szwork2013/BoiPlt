using Protiviti.Boilerplate.Server.Api.Employee;
using System.Data.Entity.ModelConfiguration;
namespace Protiviti.Boilerplate.Server.Configuration
{
    public class DivisionConfiguration : EntityTypeConfiguration<Division>
    {
        public DivisionConfiguration()
        {

            ToTable("Division");
            
            Property(d => d.Name).IsRequired();
        }
    }
}
