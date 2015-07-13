using Protiviti.Boilerplate.Server.Logging;
using System.Data.Entity;
using System.Data.Entity.SqlServer;

namespace Protiviti.Boilerplate.Server.Api.Employee
{
    public class EmployeeContextConfiguration : DbConfiguration
    {
        public EmployeeContextConfiguration()
        {
            SetExecutionStrategy("System.Data.SqlClient", () => new SqlAzureExecutionStrategy());
            SetDatabaseLogFormatter(
            (context, writeAction) => new EFDbLogFormatter(context, writeAction)); 
        }
    }
}