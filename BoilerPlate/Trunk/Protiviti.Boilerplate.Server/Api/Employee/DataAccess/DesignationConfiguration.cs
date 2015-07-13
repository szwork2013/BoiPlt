using Protiviti.Boilerplate.Server.Api.Employee;
using System.Data.Entity.ModelConfiguration;
namespace Protiviti.Boilerplate.Server.Configuration
{
    public class DesignationConfiguration : EntityTypeConfiguration<Designation>
    {
        public DesignationConfiguration()
        {

            ToTable("Designation");
            
            Property(d => d.DesignationName).IsRequired();
            Property(d => d.IsActive).IsRequired();

        }
    }
}
