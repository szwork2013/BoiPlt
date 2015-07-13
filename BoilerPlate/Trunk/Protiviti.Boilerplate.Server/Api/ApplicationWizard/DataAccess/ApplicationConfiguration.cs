using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace Protiviti.Boilerplate.Server.Api.ApplicationWizard
{
    public class ApplicationConfiguration : EntityTypeConfiguration<Application>
    {
        public ApplicationConfiguration()
        {
            this.HasOptional(e => e.Applicant)
            .WithMany()
            .HasForeignKey(d => d.ApplicantId)
            .WillCascadeOnDelete(false);

            this.HasOptional(e => e.Program)
            .WithMany()
            .HasForeignKey(d => d.ProgramId)
            .WillCascadeOnDelete(false);

            this.HasOptional(e => e.Invoice)
            .WithMany()
            .HasForeignKey(d => d.InvoiceId)
            .WillCascadeOnDelete(false);
        }
    }
}