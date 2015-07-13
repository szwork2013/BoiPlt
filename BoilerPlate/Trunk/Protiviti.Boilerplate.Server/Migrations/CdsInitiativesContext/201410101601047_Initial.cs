namespace Protiviti.Boilerplate.Server.Migrations.CdsInitiativesContext
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "CdsInitiative.Initiative",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "CdsInitiative.InitiativeTask",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        InitiativeId = c.Int(nullable: false),
                        TaskName = c.String(nullable: false, maxLength: 30),
                        ContactId = c.Int(),
                        Description = c.String(),
                        Url = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("CdsInitiative.Person", t => t.ContactId)
                .ForeignKey("CdsInitiative.Initiative", t => t.InitiativeId, cascadeDelete: true)
                .Index(t => t.InitiativeId)
                .Index(t => t.ContactId);
            
            CreateTable(
                "CdsInitiative.Person",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        Email = c.String(),
                        Blog = c.String(),
                        Twitter = c.String(),
                        Gender = c.String(maxLength: 1),
                        ImageSource = c.String(),
                        Bio = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("CdsInitiative.InitiativeTask", "InitiativeId", "CdsInitiative.Initiative");
            DropForeignKey("CdsInitiative.InitiativeTask", "ContactId", "CdsInitiative.Person");
            DropIndex("CdsInitiative.InitiativeTask", new[] { "ContactId" });
            DropIndex("CdsInitiative.InitiativeTask", new[] { "InitiativeId" });
            DropTable("CdsInitiative.Person");
            DropTable("CdsInitiative.InitiativeTask");
            DropTable("CdsInitiative.Initiative");
        }
    }
}
