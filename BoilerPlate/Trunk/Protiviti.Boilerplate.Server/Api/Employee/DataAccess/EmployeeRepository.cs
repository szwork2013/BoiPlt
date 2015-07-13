using Repository.Pattern.Repositories;
using System.Linq;
using Protiviti.Boilerplate.Server.Api.Employee;

namespace Protiviti.Data.RepositoryExtension
{
    public static class EmployeeRepository
    {
        public static int GetTotalEmployees(this IRepository<Employee> repository,bool active)
        {
            return repository.Queryable().Count();
                
        }
    }
}
