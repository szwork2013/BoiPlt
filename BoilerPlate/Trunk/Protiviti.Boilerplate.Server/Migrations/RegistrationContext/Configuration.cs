using System;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using Protiviti.Boilerplate.Server.Api.Registration;

namespace Protiviti.Boilerplate.Server.Migrations.RegistrationContext
{
    internal sealed class Configuration : DbMigrationsConfiguration<RegistrationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            MigrationsDirectory = @"Migrations\RegistrationContext";
        }
    }
}
