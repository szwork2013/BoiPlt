namespace Protiviti.Boilerplate.Server.Migrations.FileUploadContext
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initialize : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "FileUpload.File",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Name = c.String(),
                        FileImage = c.Binary(),
                        Size = c.Double(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        CreatedPersonId = c.Int(nullable: false),
                        LastChangeDate = c.DateTime(nullable: false),
                        LastChangePersonId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("FileUpload.File");
        }
    }
}
