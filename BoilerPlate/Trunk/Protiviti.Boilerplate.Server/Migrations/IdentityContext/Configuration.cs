using System;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using Protiviti.Boilerplate.Server.Api.Account;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Protiviti.Boilerplate.Server.Migrations.IdentityContext
{
    internal sealed class Configuration : DbMigrationsConfiguration<ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            MigrationsDirectory = @"Migrations\IdentityContext";
        }
        protected override void Seed(ApplicationDbContext context)
        {
            ApplicationDbInitializer.InitializeIdentityForEF(context);


            //var roles = typeof(IdentityConstants.Roles).GetFields();
            //foreach (var field in roles)
            //{
            //    var role = field.GetValue(typeof(IdentityConstants.Roles)).ToString();
            //    if (context.Roles.First(x => x.Name == role) == null)
            //    {
            //        context.Roles.Add(new IdentityRole(role));
            //    }
            //}
            ////Save Roles
            //context.SaveChanges();

            //var user = new ApplicationUser { UserName = "admin@protiviti.com", Email = "admin@protiviti.com", DisplayName = "Administrator" };
            //user.EmailConfirmed = true;
            ////user.Roles.Add(new IdentityUserRole() { user.Id, context.Roles.FirstOrDefault(x => x.Name == IdentityConstants.Roles.Administrator).Id });


            //IdentityUserRole userRole = new IdentityUserRole();
            //userRole.RoleId = context.Roles.FirstOrDefault(x => x.Name == IdentityConstants.Roles.Administrator).Id;
            //userRole.UserId = user.Id;

            //user.Roles.Add(userRole);

            //context.Users.Add(user);



        }
    }
}
