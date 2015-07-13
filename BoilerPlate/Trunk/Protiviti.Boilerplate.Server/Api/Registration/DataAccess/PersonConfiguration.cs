using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace Protiviti.Boilerplate.Server.Api.Registration
{
    public class PersonConfiguration : EntityTypeConfiguration<Person>
    {
        public PersonConfiguration()
        {
            // Relationships
            HasOptional(t => t.Address)
                .WithMany()
                .HasForeignKey(d => d.AddressId);

            HasOptional(t => t.HomeAddress)
                .WithMany()
                .HasForeignKey(d => d.HomeAddressId);

            HasOptional(t => t.Contact)
                .WithMany()
                .HasForeignKey(d => d.ContactId);

            Ignore(x => x.FullName);
            //Ignore(x => x.LastChangePerson);
            //Ignore(x => x.CreatedPerson);

            Ignore(p => p.EntityId);
            Ignore(p => p.EntityName);
            Ignore(p => p.EntityType);
            //Ignore(p => p.LogSignificance);

            Property(p => p.Version).IsConcurrencyToken().HasColumnType("TimeStamp").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Computed);

        }
    }
}