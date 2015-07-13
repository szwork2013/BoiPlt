namespace Protiviti.Boilerplate.Server.Migrations.RegistrationContext
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateRegistrationTables : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("Registration.People", "CreatedPerson_Id", "Registration.People");
            DropForeignKey("Registration.People", "LastChangePerson_Id", "Registration.People");
            DropIndex("Registration.People", new[] { "CreatedPerson_Id" });
            DropIndex("Registration.People", new[] { "LastChangePerson_Id" });
            AlterColumn("Registration.Addresses", "CreatedPersonId", c => c.Int());
            AlterColumn("Registration.Addresses", "LastChangePersonId", c => c.Int());
            AlterColumn("Registration.Contacts", "CreatedPersonId", c => c.Int());
            AlterColumn("Registration.Contacts", "LastChangePersonId", c => c.Int());
            DropColumn("Registration.People", "CreatedPerson_Id");
            DropColumn("Registration.People", "LastChangePerson_Id");
        }
        
        public override void Down()
        {
            AddColumn("Registration.People", "LastChangePerson_Id", c => c.Int(nullable: false));
            AddColumn("Registration.People", "CreatedPerson_Id", c => c.Int(nullable: false));
            AlterColumn("Registration.Contacts", "LastChangePersonId", c => c.Int(nullable: false));
            AlterColumn("Registration.Contacts", "CreatedPersonId", c => c.Int(nullable: false));
            AlterColumn("Registration.Addresses", "LastChangePersonId", c => c.Int(nullable: false));
            AlterColumn("Registration.Addresses", "CreatedPersonId", c => c.Int(nullable: false));
            CreateIndex("Registration.People", "LastChangePerson_Id");
            CreateIndex("Registration.People", "CreatedPerson_Id");
            AddForeignKey("Registration.People", "LastChangePerson_Id", "Registration.People", "Id");
            AddForeignKey("Registration.People", "CreatedPerson_Id", "Registration.People", "Id");
        }
    }
}
