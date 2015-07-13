namespace Protiviti.Boilerplate.Server.Migrations.ApplicationWizardContext
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Protiviti.Boilerplate.Server.Api.ApplicationWizard;

    internal sealed class Configuration : DbMigrationsConfiguration<ApplicationWizardContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            MigrationsDirectory = @"Migrations\ApplicationWizardContext";
        }

        protected override void Seed(ApplicationWizardContext context)
        {
            //  This method will be called after migrating to the latest version.

            context.Programs.AddOrUpdate(
              p => p.Id,
              new Program { Id = 1, Code ="ONLINE_NET_101", Name = ".Net 4.5 Online Training", Cost = 500.00M, Location = "Online", Duration = 12 },
              new Program { Id = 2, Code ="ONLINE_CSHARP_101", Name = "C Sharp Online Training", Cost = 400.00M, Location = "Online", Duration = 4 },
              new Program { Id = 3, Code ="ONLINE_JAVA_101", Name = "Java Online Training", Cost = 320.00M, Location = "Online", Duration = 8 },
              new Program { Id = 4, Code ="ONLINE_NET_201", Name = ".Net 4.5 Advanced Online Training", Cost = 440.00M, Location = "Online", Duration = 7 },
              new Program { Id = 5, Code ="ONLINE_CSHARP_201", Name = "C Sharp Advanced Online Training", Cost = 215.00M, Location = "Online", Duration = 6 },
              new Program { Id = 6, Code ="ONLINE_JAVA_201", Name = "Java Advanced Online Training", Cost = 730.00M, Location = "Online", Duration = 9 },
              new Program { Id = 7, Code ="ONLINE_NET_301", Name = ".Net 4.5 Master Online Training", Cost = 620.00M, Location = "Online", Duration = 5 },
              new Program { Id = 8, Code ="ONLINE_CSHARP_301", Name = "C Sharp Master Online Training", Cost = 290.00M, Location = "Online", Duration = 3 },
              new Program { Id = 9, Code ="ONLINE_JAVA_301", Name = "Java Master Online Training", Cost = 360.00M, Location = "Online", Duration = 2 },
              new Program { Id = 10, Code = "ONSITE_PYTHON_301", Name = "Python Master Online Training", Cost = 3640.00M, Location = "Onsite", Duration = 12 },
              new Program { Id = 11, Code = "ONSITE_NET_101 A", Name = ".Net 4.5 Online Training", Cost = 1500.00M, Location = "Onsite", Duration = 12 },
              new Program { Id = 12, Code ="ONSITE_CSHARP_101 A", Name = "C Sharp Online Training", Cost = 2400.00M, Location = "Onsite", Duration = 4 },
              new Program { Id = 13, Code ="ONSITE_JAVA_101 A", Name = "Java Online Training", Cost = 1320.00M, Location = "Onsite", Duration = 8 },
              new Program { Id = 14, Code ="ONSITE_NET_201 A", Name = ".Net 4.5 Advanced Online Training", Cost = 1440.00M, Location = "Onsite", Duration = 7 },
              new Program { Id = 15, Code ="ONSITE_CSHARP_201 A", Name = "C Sharp Advanced Online Training", Cost = 1215.00M, Location = "Onsite", Duration = 6 },
              new Program { Id = 16, Code ="ONSITE_JAVA_201 A", Name = "Java Advanced Online Training", Cost = 1730.00M, Location = "Onsite", Duration = 9 },
              new Program { Id = 17, Code ="ONSITE_NET_301 A", Name = ".Net 4.5 Master Online Training", Cost = 1620.00M, Location = "Onsite", Duration = 5 },
              new Program { Id = 18, Code ="ONSITE_CSHARP_301 A", Name = "C Sharp Master Online Training", Cost = 1290.00M, Location = "Onsite", Duration = 3 },
              new Program { Id = 19, Code ="ONSITE_JAVA_301 A", Name = "Java Master Online Training", Cost = 1360.00M, Location = "Onsite", Duration = 2 },
              new Program { Id = 20, Code = "ONSITE_PYTHON_301", Name = "Python Master Online Training", Cost = 3640.00M, Location = "Onsite", Duration = 12 },
              new Program { Id = 21, Code = "WEB_NET_101 A", Name = ".Net 4.5 Online Training", Cost = 1500.00M, Location = "Web", Duration = 12 },
              new Program { Id = 22, Code ="WEB_CSHARP_101 A", Name = "C Sharp Online Training", Cost = 2400.00M, Location = "Web", Duration = 4 },
              new Program { Id = 23, Code ="WEB_JAVA_101 A", Name = "Java Online Training", Cost = 1320.00M, Location = "Web", Duration = 8 },
              new Program { Id = 24, Code ="WEB_NET_201 A", Name = ".Net 4.5 Advanced Online Training", Cost = 1440.00M, Location = "Web", Duration = 7 },
              new Program { Id = 25, Code ="WEB_CSHARP_201 A", Name = "C Sharp Advanced Online Training", Cost = 1215.00M, Location = "Web", Duration = 6 },
              new Program { Id = 26, Code ="WEB_JAVA_201 A", Name = "Java Advanced Online Training", Cost = 1730.00M, Location = "Web", Duration = 9 },
              new Program { Id = 27, Code ="WEB_NET_301 A", Name = ".Net 4.5 Master Online Training", Cost = 1620.00M, Location = "Web", Duration = 5 },
              new Program { Id = 28, Code ="WEB_CSHARP_301 A", Name = "C Sharp Master Online Training", Cost = 1290.00M, Location = "Web", Duration = 3 },
              new Program { Id = 29, Code ="WEB_JAVA_301 A", Name = "Java Master Online Training", Cost = 1360.00M, Location = "Web", Duration = 2 }
            );

            context.Applicants.AddOrUpdate(
              p => p.Id,
              new Applicant { Id = 1, Email ="alok.gupta@protiviti.com", FirstName = "Alok", LastName = "Gupta", CompanyName = "Protiviti Inc", Department = "Dev"},
              new Applicant { Id = 2, Email = "ajay.singh@protiviti.co.in", FirstName = "Ajay", LastName = "Singh", CompanyName = "Protiviti India", Department = "Dev" },
              new Applicant { Id = 3, Email = "chandana.koti@protiviti.com", FirstName = "Chandana", LastName = "Koti", CompanyName = "Protiviti Inc", Department = "Dev" },
              new Applicant { Id = 4, Email = "pradeep.katta@protiviti.com", FirstName = "Pradeep", LastName = "Katta", CompanyName = "Protiviti Inc", Department = "Dev" },
              new Applicant { Id = 5, Email = "ben.bloomfield@protiviti.com", FirstName = "Ben", LastName = "Bloomfield", CompanyName = "Protiviti Inc", Department = "QA" },
              new Applicant { Id = 6, Email = "hanna.parker@protiviti.com", FirstName = "Hanna", LastName = "Parker", CompanyName = "Protiviti Inc", Department = "QA" },
              new Applicant { Id = 7, Email = "saleh.motan@protiviti.com", FirstName = "Saleh", LastName = "Motan", CompanyName = "Protiviti Inc", Department = "QA" },
              new Applicant { Id = 8, Email = "mike.wzorek@protiviti.com", FirstName = "Mike", LastName = "Wzorek", CompanyName = "Protiviti Inc", Department = "Dev" }
            );

            context.Payments.AddOrUpdate(
              p => p.Id,
              new Payment { Id = 1, Type = 1, AccountNumber = "1122334455", RoutingNumber = "7890", PaymentDate = new DateTime(2010, 1, 4) },
              new Payment { Id = 2, Type = 2, AccountNumber = "2233445566", RoutingNumber = "8901", PaymentDate = new DateTime(2011, 3, 9) },
              new Payment { Id = 3, Type = 3, AccountNumber = "3344556677", RoutingNumber = "9012", PaymentDate = new DateTime(2011, 5, 29) },
              new Payment { Id = 4, Type = 1, AccountNumber = "4455667788", RoutingNumber = "0123", PaymentDate = new DateTime(2014, 11, 9) },
              new Payment { Id = 5, Type = 2, AccountNumber = "5566778899", RoutingNumber = "1234", PaymentDate = new DateTime(2012, 7, 11) },
              new Payment { Id = 6, Type = 2, AccountNumber = "6677889900", RoutingNumber = "2345", PaymentDate = new DateTime(2011, 8, 3) },
              new Payment { Id = 7, Type = 1, AccountNumber = "7788990011", RoutingNumber = "3456", PaymentDate = new DateTime(2011, 6,23) },
              new Payment { Id = 8, Type = 1, AccountNumber = "7788990011", RoutingNumber = "3456", PaymentDate = new DateTime(2012, 6,23) }
            );

            context.Invoices.AddOrUpdate(
              p => p.Id,
              new Invoice { Id = 1, PaymentId = 1, Amount = 500, SubmitDate = new DateTime(2010, 1, 3) },
              new Invoice { Id = 2, PaymentId = 2, Amount = 4500, SubmitDate = new DateTime(2011, 3, 2) },
              new Invoice { Id = 3, PaymentId = 3, Amount = 560, SubmitDate = new DateTime(2011, 5, 20) },
              new Invoice { Id = 4, PaymentId = 4, Amount = 5950, SubmitDate = new DateTime(2014, 11, 1) },
              new Invoice { Id = 5, PaymentId = 5, Amount = 3450, SubmitDate = new DateTime(2012, 6, 4) },
              new Invoice { Id = 6, PaymentId = 6, Amount = 600, SubmitDate = new DateTime(2011, 4, 2) },
              new Invoice { Id = 7, PaymentId = 7, Amount = 800, SubmitDate = new DateTime(2011, 6, 23) },
              new Invoice { Id = 8, PaymentId = 8, Amount = 800, SubmitDate = new DateTime(2012, 6, 23) }
            );

            context.Applications.AddOrUpdate(
              p => p.Id,
              new Application { Id = 1, Name = "Alok's Application", Status = "Open", ApplicantId = 1, ProgramId = 1, InvoiceId = 1, SubmittedDate = new DateTime(2010, 1, 3), CreatedDate = DateTime.Now, LastChangedDate = DateTime.Now },
              new Application { Id = 2, Name = "Ajay's Application", Status = "Closed", ApplicantId = 2, ProgramId = 2, InvoiceId = 2, SubmittedDate = new DateTime(2011, 3, 2), CreatedDate = DateTime.Now, LastChangedDate = DateTime.Now },
              new Application { Id = 3, Name = "Chandana's Application", Status = "Pending", ApplicantId = 3, ProgramId = 3, InvoiceId = 3, SubmittedDate = new DateTime(2011, 5, 20), CreatedDate = DateTime.Now, LastChangedDate = DateTime.Now },
              new Application { Id = 4, Name = "Pradeep's Application", Status = "Closed", ApplicantId = 4, ProgramId = 4, InvoiceId = 4, SubmittedDate = new DateTime(2014, 11, 1), CreatedDate = DateTime.Now, LastChangedDate = DateTime.Now },
              new Application { Id = 5, Name = "Ben's Application", Status = "Open", ApplicantId = 5, ProgramId = 5, InvoiceId = 5, SubmittedDate = new DateTime(2012, 6, 4), CreatedDate = DateTime.Now, LastChangedDate = DateTime.Now },
              new Application { Id = 6, Name = "Hanna's Application", Status = "Closed", ApplicantId = 6, ProgramId = 6, InvoiceId = 6, SubmittedDate = new DateTime(2011, 4, 2), CreatedDate = DateTime.Now, LastChangedDate = DateTime.Now },
              new Application { Id = 7, Name = "Sal's Application", Status = "Pending", ApplicantId = 7, ProgramId = 7, InvoiceId = 7, SubmittedDate = new DateTime(2011, 6, 23), CreatedDate = DateTime.Now, LastChangedDate = DateTime.Now },
              new Application { Id = 8, Name = "Mike's Application", Status = "Pending", ApplicantId = 8, ProgramId = 8, InvoiceId = 8, SubmittedDate = new DateTime(2012, 6, 23), CreatedDate = DateTime.Now, LastChangedDate = DateTime.Now }
            );
        }
    }
}
