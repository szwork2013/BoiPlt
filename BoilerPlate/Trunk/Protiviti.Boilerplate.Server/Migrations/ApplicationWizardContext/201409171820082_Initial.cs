namespace Protiviti.Boilerplate.Server.Migrations.ApplicationWizardContext
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "ApplicationWizard.Applicants",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        CompanyName = c.String(),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "ApplicationWizard.Applications",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Applicantid = c.Int(nullable: false),
                        ProgramId = c.Int(nullable: false),
                        InvoiceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("ApplicationWizard.Applicants", t => t.Applicantid, cascadeDelete: true)
                .ForeignKey("ApplicationWizard.Invoices", t => t.InvoiceId, cascadeDelete: true)
                .ForeignKey("ApplicationWizard.Programs", t => t.ProgramId, cascadeDelete: true)
                .Index(t => t.Applicantid)
                .Index(t => t.ProgramId)
                .Index(t => t.InvoiceId);
            
            CreateTable(
                "ApplicationWizard.Invoices",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Amount = c.Int(nullable: false),
                        PaymentId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("ApplicationWizard.Payments", t => t.PaymentId, cascadeDelete: true)
                .Index(t => t.PaymentId);
            
            CreateTable(
                "ApplicationWizard.Payments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Type = c.Int(nullable: false),
                        AccountNumber = c.String(),
                        RoutingNumber = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "ApplicationWizard.Programs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Code = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("ApplicationWizard.Applications", "ProgramId", "ApplicationWizard.Programs");
            DropForeignKey("ApplicationWizard.Applications", "InvoiceId", "ApplicationWizard.Invoices");
            DropForeignKey("ApplicationWizard.Invoices", "PaymentId", "ApplicationWizard.Payments");
            DropForeignKey("ApplicationWizard.Applications", "Applicantid", "ApplicationWizard.Applicants");
            DropIndex("ApplicationWizard.Invoices", new[] { "PaymentId" });
            DropIndex("ApplicationWizard.Applications", new[] { "InvoiceId" });
            DropIndex("ApplicationWizard.Applications", new[] { "ProgramId" });
            DropIndex("ApplicationWizard.Applications", new[] { "Applicantid" });
            DropTable("ApplicationWizard.Programs");
            DropTable("ApplicationWizard.Payments");
            DropTable("ApplicationWizard.Invoices");
            DropTable("ApplicationWizard.Applications");
            DropTable("ApplicationWizard.Applicants");
        }
    }
}
