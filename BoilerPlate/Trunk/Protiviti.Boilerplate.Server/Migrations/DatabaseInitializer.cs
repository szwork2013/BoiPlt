using Protiviti.Boilerplate.Server.Api.Account;
using System.Data.Entity;

namespace Protiviti.Boilerplate.Server.Migrations
{
    /// <summary>
    /// Class to Initialize Databases
    /// </summary>
    public class DatabaseInitializer
    {
        /// <summary>
        /// Initializes databases (at Application Start)
        /// </summary>
        static public void InitializeDatabases()
        {

            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ApplicationDbContext, IdentityContext.Configuration>());
            (new ApplicationDbContext()).Database.Initialize(true);

            Database.SetInitializer(new MigrateDatabaseToLatestVersion<Api.ApplicationWizard.ApplicationWizardContext, ApplicationWizardContext.Configuration>());
            (new Api.ApplicationWizard.ApplicationWizardContext()).Database.Initialize(true);

            Database.SetInitializer(new MigrateDatabaseToLatestVersion<Api.Registration.RegistrationDbContext, RegistrationContext.Configuration>());
            (new Api.Registration.RegistrationDbContext()).Database.Initialize(true);

            Database.SetInitializer(new MigrateDatabaseToLatestVersion<Api.Initiatives.InitiativeDbContext, CdsInitiativesContext.Configuration>());
            (new Api.Initiatives.InitiativeDbContext()).Database.Initialize(true);

            Database.SetInitializer(new MigrateDatabaseToLatestVersion<Api.FileUpload.DataAccess.FileUploadDbContext, FileUploadContext.Configuration>());
            (new Api.FileUpload.DataAccess.FileUploadDbContext()).Database.Initialize(true);

            Database.SetInitializer(new MigrateDatabaseToLatestVersion<Api.Album.AlbumContext, AlbumContext.Configuration>());
            (new Api.Album.AlbumContext()).Database.Initialize(true);
          

            //in order to create temp members
            ApplicationDbInitializer.CreateTempUsers();
        }
    }
}