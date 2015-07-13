namespace Protiviti.Boilerplate.Server.Migrations.FileUploadContext
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedDataURLToFile : DbMigration
    {
        public override void Up()
        {
            AddColumn("FileUpload.File", "DataURL", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("FileUpload.File", "DataURL");
        }
    }
}
