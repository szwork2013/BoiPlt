using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;


namespace Protiviti.Boilerplate.Server.Api.Initiatives
{
    public class InitiativeTaskConfiguration : EntityTypeConfiguration<InitiativeTask>
    {
        public InitiativeTaskConfiguration()
        {
            ToTable("CdsInitiative.InitiativeTask");

            HasRequired(x => x.Contact)
                .WithMany()
                .HasForeignKey(y => y.ContactId);

            HasRequired(x => x.Initiative)
                .WithMany(y => y.Tasks)
                .HasForeignKey(x => x.InitiativeId);

        }
    }
}