using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace Protiviti.Boilerplate.Server.Api.ApplicationWizard
{
    public class InvoiceConfiguration : EntityTypeConfiguration<Invoice>
    {
        public InvoiceConfiguration()
        {
            this.HasOptional(e => e.Payment)
            .WithMany()
            .HasForeignKey(d => d.PaymentId)
            .WillCascadeOnDelete(false);
        }
    }
}