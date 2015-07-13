using Microsoft.AspNet.Identity.EntityFramework;
using Protiviti.Data.Logging;
using System.Data.Entity;
using Protiviti.Boilerplate.Server.Api.Account.Entity;

namespace Protiviti.Boilerplate.Server.Api.Account
{
    [DbConfigurationTypeAttribute(typeof(Configuration.CacheConfiguration))]
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        private EFLogging _logger = EFLogging.Logger;
        public ApplicationDbContext()
            : base(nameOrConnectionString: "IdentityContext", throwIfV1Schema: false)
        {
            Database.Log = s => _logger.Log(s);
        }


        public DbSet<Client> Clients { get; set; }

        public static ApplicationDbContext Create()
        {

            return new ApplicationDbContext();
        }
    }
}