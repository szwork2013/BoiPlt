namespace Protiviti.Boilerplate.Server.Migrations.FileUploadContext
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RenamedColumnToFileType : DbMigration
    {
        public override void Up()
        {
            AddColumn("FileUpload.File", "FileType", c => c.String());
            DropColumn("FileUpload.File", "Type");
        }
        
        public override void Down()
        {
            AddColumn("FileUpload.File", "Type", c => c.String());
            DropColumn("FileUpload.File", "FileType");
        }
    }
}
