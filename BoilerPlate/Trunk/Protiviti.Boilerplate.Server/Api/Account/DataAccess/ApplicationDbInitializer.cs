using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Protiviti.Boilerplate.Server.Api.Registration;
using System.Data.Entity;
namespace Protiviti.Boilerplate.Server.Api.Account
{
    public class ApplicationDbInitializer : DropCreateDatabaseIfModelChanges<ApplicationDbContext>
    {
        protected override void Seed(ApplicationDbContext context)
        {
            InitializeIdentityForEF(context);
            base.Seed(context);
        }

        public static void InitializeIdentityForEF(ApplicationDbContext db)
        {
            var userStore = new UserStore<ApplicationUser>(db);
            var userManager = new ApplicationUserManager(userStore);
            userManager.UserValidator = new UserValidator<ApplicationUser>(userManager)
            {
                AllowOnlyAlphanumericUserNames = false
            };
            var roleStore = new RoleStore<IdentityRole>(db);
            var roleManager = new ApplicationRoleManager(roleStore);

            const string name = "admin@protiviti.com";
            const string password = "Admin@123";
            const string displayName = "Administrator";


            var roles = typeof(IdentityConstants.Roles).GetFields();
            foreach (var field in roles)
            {
                var role = field.GetValue(typeof(IdentityConstants.Roles)).ToString();
                if (!roleManager.RoleExists(role))
                {
                    roleManager.Create(new IdentityRole(role));
                }
            }


            var user = userManager.FindByName(name);

            if (user == null)
            {
                user = new ApplicationUser { UserName = name, Email = name, DisplayName = displayName };
                var result = userManager.Create(user, password);

                // Set Email confirmation property (see note above):
                user.EmailConfirmed = true;
                result = userManager.SetLockoutEnabled(user.Id, false);
            }

            // Add user admin to Role Admin if not already added

            var rolesForUser = userManager.GetRoles(user.Id);

            if (!rolesForUser.Contains(IdentityConstants.Roles.Administrator))
            {
                var result = userManager.AddToRole(user.Id, IdentityConstants.Roles.Administrator);
            }
        }

        public static void CreateTempUsers()
        {
            ApplicationDbContext db = new ApplicationDbContext();
            var userStore = new UserStore<ApplicationUser>(db);
            var userManager = new ApplicationUserManager(userStore);
            var registration = new RegistrationController();

            userManager.UserValidator = new UserValidator<ApplicationUser>(userManager)
            {
                AllowOnlyAlphanumericUserNames = false
            };
            var roleStore = new RoleStore<IdentityRole>(db);
            var roleManager = new ApplicationRoleManager(roleStore);

            string userName = "Test{0}@protiviti.com";
            string displayName = "Test{0}";
            for (int i = 1; i <= 5; i++)
            {
                var modifiedUserName = string.Format(userName, i.ToString());
                var user = userManager.FindByName(modifiedUserName);

                if (user == null)
                {
                    user = new ApplicationUser { UserName = modifiedUserName, Email = modifiedUserName, DisplayName = string.Format(displayName, i.ToString()) };

                    var result = userManager.Create(user, "Test@123");

                    // Set Email confirmation property (see note above):
                    user.EmailConfirmed = true;
                    result = userManager.SetLockoutEnabled(user.Id, false);

                    //register the user

                    var person = new Protiviti.Boilerplate.Server.Api.Registration.Person
                    {
                        UserName = modifiedUserName,
                        FirstName = string.Format("Test {0}", i.ToString()),
                        LastName = "Test",
                        Contact = new Contact { Phone = "0000000009", Email = modifiedUserName },
                        Address = new Address { AddressLine1 = "Street A1", AddressLine2 = "Sector-34", CityLocality = "Noida", Country = "India", StateProvince = "New Delhi" }
                    };

                    registration.CreatePerson(person);

                    //Adding roles
                    if (i % 2 != 0)
                    {
                        var rolesForUser = userManager.GetRoles(user.Id);

                        if (rolesForUser!=null && !rolesForUser.Contains(IdentityConstants.Roles.Member))
                        {
                            result = userManager.AddToRole(user.Id, IdentityConstants.Roles.Member);
                        }
                    }
                }
            }
        }
    }
}