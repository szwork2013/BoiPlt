namespace Protiviti.Boilerplate.Server.Migrations.IdentityContext
{
    using Protiviti.Boilerplate.Server.Api.Account;
    using Protiviti.Boilerplate.Server.Api.Account.Entity;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;

    public partial class Add_Table_Clients : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Clients",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Secret = c.String(nullable: false),
                        Name = c.String(nullable: false, maxLength: 100),
                        ApplicationType = c.Int(nullable: false),
                        Active = c.Boolean(nullable: false),
                        RefreshTokenLifeTime = c.Int(nullable: false),
                        AllowedOrigin = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.Id);

            Sql("insert into dbo.Clients values ('ProtivitiBoilerplate','5YV7M1r981yoGhELyB84aC+KiYksxZf1OY3++C1CtRM=','Protiviti Boilerplate Project',0,1,7200,'http://localhost')");

        }
        
        public override void Down()
        {
            DropTable("dbo.Clients");
        }

       
    }
}
