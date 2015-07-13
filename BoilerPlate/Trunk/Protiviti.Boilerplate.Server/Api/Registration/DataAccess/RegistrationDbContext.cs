using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace Protiviti.Boilerplate.Server.Api.Registration
{
    [DbConfigurationTypeAttribute(typeof(Configuration.Configuration))]
    public class RegistrationDbContext : DbContext
    {
        public RegistrationDbContext()
            : base("name=RegistrationDbContext")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Entity<Person>().ToTable("People", schemaName: "Registration");
            modelBuilder.Entity<Person>().HasRequired(p => p.Address).WithOptional();
            modelBuilder.Entity<Person>().HasRequired(p => p.HomeAddress).WithOptional();
            modelBuilder.Entity<Person>().HasRequired(p => p.Contact).WithOptional();
            //modelBuilder.Entity<Person>().HasRequired(p => p.CreatedPerson).WithOptional();
            //modelBuilder.Entity<Person>().HasRequired(p => p.LastChangePerson).WithOptional();

            modelBuilder.Entity<Address>().ToTable("Addresses", schemaName: "Registration");
            modelBuilder.Entity<Contact>().ToTable("Contacts", schemaName: "Registration");


        }

        public DbSet<Person> People { get; set; }

        public DbSet<Address> Addresses { get; set; }

        public DbSet<Contact> Contact { get; set; }
    }
}
