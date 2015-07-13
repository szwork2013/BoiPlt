namespace Protiviti.Boilerplate.Server.Migrations.ApplicationWizardContext
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedApplication : DbMigration
    {
        public override void Up()
        {
            DropIndex("ApplicationWizard.Applications", new[] { "Applicantid" });
            CreateIndex("ApplicationWizard.Applications", "ApplicantId");
        }
        
        public override void Down()
        {
            DropIndex("ApplicationWizard.Applications", new[] { "ApplicantId" });
            CreateIndex("ApplicationWizard.Applications", "Applicantid");
        }
    }
}
