using Protiviti.Boilerplate.Server.Logging;
using System.Data.Entity;
using System.Data.Entity.SqlServer;

namespace Protiviti.Boilerplate.Server.Configuration
{
    public class Configuration : DbConfiguration
    {
        public Configuration()
        {
            SetExecutionStrategy("System.Data.SqlClient", () => new SqlAzureExecutionStrategy());
            SetDatabaseLogFormatter(
            (context, writeAction) => new EFDbLogFormatter(context, writeAction)); 
        }
    }
}