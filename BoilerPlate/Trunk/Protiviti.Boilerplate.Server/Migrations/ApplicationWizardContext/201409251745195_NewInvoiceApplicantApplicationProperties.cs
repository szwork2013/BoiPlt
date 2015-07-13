namespace Protiviti.Boilerplate.Server.Migrations.ApplicationWizardContext
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewInvoiceApplicantApplicationProperties : DbMigration
    {
        public override void Up()
        {
            AddColumn("ApplicationWizard.Applicants", "PhoneNumber", c => c.String());
            AddColumn("ApplicationWizard.Applicants", "Department", c => c.String());
            AddColumn("ApplicationWizard.Applicants", "Track", c => c.String());
            AddColumn("ApplicationWizard.Applications", "Name", c => c.String());
            AddColumn("ApplicationWizard.Applications", "Status", c => c.String());
            AddColumn("ApplicationWizard.Applications", "SubmittedDate", c => c.DateTime(nullable: false));
            AddColumn("ApplicationWizard.Applications", "CreatedDate", c => c.DateTime(nullable: false));
            AddColumn("ApplicationWizard.Applications", "LastChangedDate", c => c.DateTime(nullable: false));
            AddColumn("ApplicationWizard.Invoices", "SubmitDate", c => c.DateTime(nullable: false));
            AddColumn("ApplicationWizard.Payments", "PaymentDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("ApplicationWizard.Payments", "PaymentDate");
            DropColumn("ApplicationWizard.Invoices", "SubmitDate");
            DropColumn("ApplicationWizard.Applications", "LastChangedDate");
            DropColumn("ApplicationWizard.Applications", "CreatedDate");
            DropColumn("ApplicationWizard.Applications", "SubmittedDate");
            DropColumn("ApplicationWizard.Applications", "Status");
            DropColumn("ApplicationWizard.Applications", "Name");
            DropColumn("ApplicationWizard.Applicants", "Track");
            DropColumn("ApplicationWizard.Applicants", "Department");
            DropColumn("ApplicationWizard.Applicants", "PhoneNumber");
        }
    }
}
