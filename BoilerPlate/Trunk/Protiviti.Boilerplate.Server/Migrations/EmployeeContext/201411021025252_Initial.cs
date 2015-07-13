namespace Protiviti.Boilerplate.Server.Migrations.EmployeeContext
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Division",
                c => new
                    {
                        DivisionID = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.DivisionID);
            
            CreateTable(
                "dbo.Employee",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        LastName = c.String(nullable: false, maxLength: 50),
                        FirstName = c.String(nullable: false, maxLength: 50),
                        Location = c.String(),
                        DivisionID = c.Int(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        DesignationID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Designation", t => t.DesignationID, cascadeDelete: true)
                .ForeignKey("dbo.Division", t => t.DivisionID, cascadeDelete: true)
                .Index(t => t.DivisionID)
                .Index(t => t.DesignationID);
            
            CreateTable(
                "dbo.Designation",
                c => new
                    {
                        DesignationID = c.Int(nullable: false, identity: true),
                        DesignationName = c.String(nullable: false, maxLength: 20),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.DesignationID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Employee", "DivisionID", "dbo.Division");
            DropForeignKey("dbo.Employee", "DesignationID", "dbo.Designation");
            DropIndex("dbo.Employee", new[] { "DesignationID" });
            DropIndex("dbo.Employee", new[] { "DivisionID" });
            DropTable("dbo.Designation");
            DropTable("dbo.Employee");
            DropTable("dbo.Division");
        }
    }
}
