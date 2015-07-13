namespace Protiviti.Boilerplate.Server.Migrations.FileUploadContext
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RenamedColumnsFirefoxIssue : DbMigration
    {
        public override void Up()
        {
            AddColumn("FileUpload.File", "FileName", c => c.String());
            AddColumn("FileUpload.File", "FileSize", c => c.Double(nullable: false));
            DropColumn("FileUpload.File", "Name");
            DropColumn("FileUpload.File", "Size");
        }
        
        public override void Down()
        {
            AddColumn("FileUpload.File", "Size", c => c.Double(nullable: false));
            AddColumn("FileUpload.File", "Name", c => c.String());
            DropColumn("FileUpload.File", "FileSize");
            DropColumn("FileUpload.File", "FileName");
        }
    }
}
