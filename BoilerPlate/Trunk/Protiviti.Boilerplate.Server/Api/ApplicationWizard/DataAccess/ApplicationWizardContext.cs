using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace Protiviti.Boilerplate.Server.Api.ApplicationWizard
{
    [DbConfigurationTypeAttribute(typeof(Configuration.Configuration))]
    public class ApplicationWizardContext : DbContext
    {
        public ApplicationWizardContext() : base("name=ApplicationWizardContext")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Entity<Application>().ToTable("Applications", schemaName: "ApplicationWizard");
            modelBuilder.Entity<Program>().ToTable("Programs", schemaName: "ApplicationWizard");
            modelBuilder.Entity<Invoice>().ToTable("Invoices", schemaName: "ApplicationWizard");
            modelBuilder.Entity<Payment>().ToTable("Payments", schemaName: "ApplicationWizard");
            modelBuilder.Entity<Applicant>().ToTable("Applicants", schemaName: "ApplicationWizard");
        }


        public DbSet<Application> Applications { get; set; }

        public DbSet<Program> Programs { get; set; }

        public DbSet<Invoice> Invoices { get; set; }

        public DbSet<Payment> Payments { get; set; }

        public DbSet<Applicant> Applicants { get; set; }
    }
}
