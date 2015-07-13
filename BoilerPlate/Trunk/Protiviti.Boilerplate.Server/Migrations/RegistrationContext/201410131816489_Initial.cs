namespace Protiviti.Boilerplate.Server.Migrations.RegistrationContext
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "Registration.Addresses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UniqueId = c.Guid(nullable: false),
                        Version = c.Binary(),
                        Organization = c.String(),
                        AddressLine1 = c.String(),
                        AddressLine2 = c.String(),
                        CityLocality = c.String(),
                        StateProvince = c.String(),
                        PostalCode = c.String(),
                        Country = c.String(),
                        Attention = c.String(),
                        PONumber = c.String(),
                        Latitude = c.Decimal(precision: 18, scale: 2),
                        Longitude = c.Decimal(precision: 18, scale: 2),
                        Duplicate = c.Boolean(),
                        Verified = c.Boolean(),
                        CreatedDate = c.DateTime(nullable: false),
                        CreatedPersonId = c.Int(nullable: false),
                        LastChangeDate = c.DateTime(nullable: false),
                        LastChangePersonId = c.Int(nullable: false),
                        SiteNumber = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "Registration.Contacts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UniqueId = c.Guid(nullable: false),
                        Version = c.Binary(),
                        Email = c.String(),
                        Phone = c.String(),
                        Fax = c.String(),
                        Cell = c.String(),
                        PhoneCountryCode = c.String(),
                        PhoneExt = c.String(),
                        FaxCountryCode = c.String(),
                        FaxExt = c.String(),
                        CellCountryCode = c.String(),
                        URL = c.String(),
                        PhoneType = c.String(),
                        AlternatePhone = c.String(),
                        AlternatePhoneType = c.String(),
                        SecondaryEmail = c.String(),
                        CCEmail = c.String(),
                        Birthday = c.DateTime(nullable: false),
                        PrimaryLanguage = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        CreatedPersonId = c.Int(nullable: false),
                        LastChangeDate = c.DateTime(nullable: false),
                        LastChangePersonId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "Registration.People",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        UniqueId = c.Guid(nullable: false),
                        Version = c.Binary(),
                        TypeId = c.Int(),
                        UserName = c.String(),
                        Title = c.String(),
                        Salutation = c.String(),
                        FirstName = c.String(nullable: false),
                        MiddleName = c.String(),
                        LastName = c.String(nullable: false),
                        Suffix = c.String(),
                        AddressId = c.Int(),
                        HomeAddressId = c.Int(),
                        ContactId = c.Int(),
                        IsActive = c.Boolean(),
                        CreatedDate = c.DateTime(nullable: false),
                        CreatedPersonId = c.Int(),
                        LastChangeDate = c.DateTime(nullable: false),
                        LastChangePersonId = c.Int(),
                        CreatedPerson_Id = c.Int(nullable: false),
                        LastChangePerson_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("Registration.Addresses", t => t.Id)
                .ForeignKey("Registration.Contacts", t => t.Id)
                .ForeignKey("Registration.People", t => t.CreatedPerson_Id)
                .ForeignKey("Registration.People", t => t.LastChangePerson_Id)
                .Index(t => t.Id)
                .Index(t => t.CreatedPerson_Id)
                .Index(t => t.LastChangePerson_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("Registration.People", "LastChangePerson_Id", "Registration.People");
            DropForeignKey("Registration.People", "CreatedPerson_Id", "Registration.People");
            DropForeignKey("Registration.People", "Id", "Registration.Contacts");
            DropForeignKey("Registration.People", "Id", "Registration.Addresses");
            DropIndex("Registration.People", new[] { "LastChangePerson_Id" });
            DropIndex("Registration.People", new[] { "CreatedPerson_Id" });
            DropIndex("Registration.People", new[] { "Id" });
            DropTable("Registration.People");
            DropTable("Registration.Contacts");
            DropTable("Registration.Addresses");
        }
    }
}
