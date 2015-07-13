using System;
namespace Protiviti.Boilerplate.Server.Api.ApplicationWizard
{
    interface IApplicationWizardContext
    {
        System.Data.Entity.DbSet<Applicant> Applicants { get; set; }
        System.Data.Entity.DbSet<Application> Applications { get; set; }
        System.Data.Entity.DbSet<Invoice> Invoices { get; set; }
        System.Data.Entity.DbSet<Payment> Payments { get; set; }
        System.Data.Entity.DbSet<Program> Programs { get; set; }
    }
}
