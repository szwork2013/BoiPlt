using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;
using Repository.Pattern.Ef6;

namespace Protiviti.Boilerplate.Server.Api.Initiatives
{
    public class InitiativeDbContext : DataContext
    {
        private const string _contextName = "CdsInitiativesContext";
        public static string ContextName { get { return _contextName; } }

        public InitiativeDbContext()
            : base(ContextName)
        {
            Configuration.ProxyCreationEnabled = false;
            Configuration.LazyLoadingEnabled = false;

        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Entity<Initiative>().ToTable("Initiative", schemaName: "CdsInitiative");
            modelBuilder.Entity<InitiativeTask>().ToTable("InitiativeTask", schemaName: "CdsInitiative");
            modelBuilder.Entity<Person>().ToTable("Person", schemaName: "CdsInitiative");

            modelBuilder.Configurations.Add(new InitiativeConfiguration());
            modelBuilder.Configurations.Add(new InitiativeTaskConfiguration());
        }

        public DbSet<Initiative> Initiatives { get; set; }
        public DbSet<InitiativeTask> InitiativeTasks { get; set; }
        public DbSet<Person> Persons { get; set; }

    }
}