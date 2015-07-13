namespace Protiviti.Boilerplate.Server.Migrations.RegistrationContext
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FieldsSetAsMaxLength : DbMigration
    {
        public override void Up()
        {
            AlterColumn("Registration.Contacts", "Phone", c => c.String());
            AlterColumn("Registration.Contacts", "Cell", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("Registration.Contacts", "Cell", c => c.String(maxLength: 10));
            AlterColumn("Registration.Contacts", "Phone", c => c.String(maxLength: 10));
        }
    }
}
