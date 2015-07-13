namespace Protiviti.Boilerplate.Server.Migrations.IdentityContext
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_ApplicationUser_IsActive_Column : DbMigration
    {
        public override void Up()
        {
            Sql("IF COL_LENGTH('dbo.AspNetUsers','IsActive') IS NULL BEGIN ALTER TABLE [dbo].[AspNetUsers] ADD [IsActive] [bit] NOT NULL DEFAULT 0 END");
            Sql("update dbo.AspNetUsers set IsActive=1 where username='admin@protiviti.com'");
        }
        
        public override void Down()
        {
        }
    }
}
