namespace Protiviti.Boilerplate.Server.Migrations.FileUploadContext
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedFileImageAndTypeColumns : DbMigration
    {
        public override void Up()
        {
            AddColumn("FileUpload.File", "FileImage", c => c.Binary());
            AddColumn("FileUpload.File", "Type", c => c.String());
            DropColumn("FileUpload.File", "DataURL");
        }
        
        public override void Down()
        {
            AddColumn("FileUpload.File", "DataURL", c => c.String());
            DropColumn("FileUpload.File", "Type");
            DropColumn("FileUpload.File", "FileImage");
        }
    }
}
