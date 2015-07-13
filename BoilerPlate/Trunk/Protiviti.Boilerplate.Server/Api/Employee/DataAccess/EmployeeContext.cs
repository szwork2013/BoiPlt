using Repository.Pattern.Ef6;
using Protiviti.Boilerplate.Server.Configuration;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Protiviti.Data.Logging;

namespace Protiviti.Boilerplate.Server.Api.Employee
{
    
    [DbConfigurationType(typeof(Configuration.Configuration))]
    public class EmployeeContext :  DataContext
    {
        private EFLogging _logger = EFLogging.Logger;
        public EmployeeContext()
            : base(nameOrConnectionString: "EmployeeContext")
        {
            Database.SetInitializer(new EmployeeDbInitializer());
            Configuration.ValidateOnSaveEnabled = false;

            Database.Log = s => _logger.Log(s);
        }

        static EmployeeContext()
        {
            Database.SetInitializer(new EmployeeDbInitializer());
        }

        #region Test
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Designation> Designations { get; set; }
        public DbSet<Division> Addresses { get; set; }
        #endregion

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Configurations.Add(new DesignationConfiguration());
                                        

            base.OnModelCreating(modelBuilder);
        }
    }

    
}