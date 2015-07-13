namespace Protiviti.Boilerplate.Server.Migrations.RegistrationContext
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SetMaxColLengthForContacts : DbMigration
    {
        public override void Up()
        {
            AlterColumn("Registration.Contacts", "Phone", c => c.String(maxLength: 15));
            AlterColumn("Registration.Contacts", "Cell", c => c.String(maxLength: 15));
        }
        
        public override void Down()
        {
            AlterColumn("Registration.Contacts", "Cell", c => c.String());
            AlterColumn("Registration.Contacts", "Phone", c => c.String());
        }
    }
}
