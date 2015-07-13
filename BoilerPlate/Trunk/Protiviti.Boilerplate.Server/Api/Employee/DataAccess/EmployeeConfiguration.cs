using System.Data.Entity.ModelConfiguration;
using Protiviti.Boilerplate.Server.Api.Employee;

namespace Protiviti.Boilerplate.Server.Configuration
{
    public class EmployeeConfiguration : EntityTypeConfiguration<Employee>
    {
        public EmployeeConfiguration()
        {

            ToTable("Employee");
            Property(e => e.FirstName).HasMaxLength(50).IsRequired();
            Property(e => e.LastName).HasMaxLength(50).IsRequired();
            Property(e => e.Location).IsRequired();
            Property(e => e.IsActive).IsRequired();

           // Property(e => e.EnrollmentDate).HasColumnType("Date");
            HasRequired(e => e.Designation).WithMany(e => e.Employees).HasForeignKey(e => e.DesignationID);
            HasRequired(e => e.Division).WithMany(e => e.Employees).HasForeignKey(e => e.DivisionID);
        }
    }
}
