namespace Protiviti.Boilerplate.Server.Migrations.FileUploadContext
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveImageColumn : DbMigration
    {
        public override void Up()
        {
            DropColumn("FileUpload.File", "FileImage");
        }
        
        public override void Down()
        {
            AddColumn("FileUpload.File", "FileImage", c => c.Binary());
        }
    }
}
