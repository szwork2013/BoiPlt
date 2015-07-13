namespace Protiviti.Boilerplate.Server.Migrations.CdsInitiativesContext
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitiativeTaskAddDateColumns : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("CdsInitiative.InitiativeTask", "ContactId", "CdsInitiative.Person");
            DropIndex("CdsInitiative.InitiativeTask", new[] { "ContactId" });
            AddColumn("CdsInitiative.InitiativeTask", "StartDate", c => c.DateTime(nullable: false, defaultValueSql:"GETUTCDATE()"));
            AddColumn("CdsInitiative.InitiativeTask", "EndDate", c => c.DateTime());
            AlterColumn("CdsInitiative.InitiativeTask", "ContactId", c => c.Int(nullable: false));
            CreateIndex("CdsInitiative.InitiativeTask", "ContactId");
            AddForeignKey("CdsInitiative.InitiativeTask", "ContactId", "CdsInitiative.Person", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("CdsInitiative.InitiativeTask", "ContactId", "CdsInitiative.Person");
            DropIndex("CdsInitiative.InitiativeTask", new[] { "ContactId" });
            AlterColumn("CdsInitiative.InitiativeTask", "ContactId", c => c.Int());
            DropColumn("CdsInitiative.InitiativeTask", "EndDate");
            DropColumn("CdsInitiative.InitiativeTask", "StartDate");
            CreateIndex("CdsInitiative.InitiativeTask", "ContactId");
            AddForeignKey("CdsInitiative.InitiativeTask", "ContactId", "CdsInitiative.Person", "Id");
        }
    }
}
