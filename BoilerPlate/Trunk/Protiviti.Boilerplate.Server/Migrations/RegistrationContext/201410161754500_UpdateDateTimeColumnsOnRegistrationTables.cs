namespace Protiviti.Boilerplate.Server.Migrations.RegistrationContext
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateDateTimeColumnsOnRegistrationTables : DbMigration
    {
        public override void Up()
        {
            AlterColumn("Registration.Addresses", "CreatedDate", c => c.DateTime());
            AlterColumn("Registration.Addresses", "LastChangeDate", c => c.DateTime());
            AlterColumn("Registration.Contacts", "Birthday", c => c.DateTime());
            AlterColumn("Registration.Contacts", "CreatedDate", c => c.DateTime());
            AlterColumn("Registration.Contacts", "LastChangeDate", c => c.DateTime());
            AlterColumn("Registration.People", "CreatedDate", c => c.DateTime());
            AlterColumn("Registration.People", "LastChangeDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("Registration.People", "LastChangeDate", c => c.DateTime(nullable: false));
            AlterColumn("Registration.People", "CreatedDate", c => c.DateTime(nullable: false));
            AlterColumn("Registration.Contacts", "LastChangeDate", c => c.DateTime(nullable: false));
            AlterColumn("Registration.Contacts", "CreatedDate", c => c.DateTime(nullable: false));
            AlterColumn("Registration.Contacts", "Birthday", c => c.DateTime(nullable: false));
            AlterColumn("Registration.Addresses", "LastChangeDate", c => c.DateTime(nullable: false));
            AlterColumn("Registration.Addresses", "CreatedDate", c => c.DateTime(nullable: false));
        }
    }
}
