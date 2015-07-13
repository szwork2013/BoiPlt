namespace Protiviti.Boilerplate.Server.Migrations.ApplicationWizardContext
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewProgramsProperty : DbMigration
    {
        public override void Up()
        {
            AddColumn("ApplicationWizard.Programs", "Cost", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("ApplicationWizard.Programs", "Location", c => c.String());
            AddColumn("ApplicationWizard.Programs", "Duration", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("ApplicationWizard.Programs", "Duration");
            DropColumn("ApplicationWizard.Programs", "Location");
            DropColumn("ApplicationWizard.Programs", "Cost");
        }
    }
}
