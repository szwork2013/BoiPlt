using Breeze.WebApi2;
using Protiviti.Boilerplate.Server.Logging;
using System;
using System.Linq;
using System.Web.Http;
using System.Threading.Tasks;
using Breeze.ContextProvider;
using Newtonsoft.Json.Linq;
using System.Web.Http.Description;
using System.Security.Claims;
using Protiviti.Boilerplate.Server.Api.Account;
using Protiviti.Boilerplate.Server.Filters;

namespace Protiviti.Boilerplate.Server.Api.Employee
{
    [SlabLoggingFilter]
    [BreezeController]
    [RoutePrefix("api/employee")]
    //[CustomAuthorize(Roles = IdentityConstants.Roles.Administrator + "," + IdentityConstants.Roles.Member)]
    [Authorize(Roles = IdentityConstants.Roles.Administrator + "," + IdentityConstants.Roles.Member)]
    public class EmployeeController : BaseController
    {
        public EmployeeController()
        {

        }

        /// <summary>
        /// Get the list of all employees
        /// </summary>
        /// <remarks>list of all employees</remarks>
        /// <response code="400">Bad request</response>
        /// <response code="500">Internal Server Error</response>
        [HttpGet]
        [Route("Employees")]
        [ResponseType(typeof(Employee))]
        public IQueryable<Employee> Employees()
        {

            var identity = (ClaimsIdentity)User.Identity;
            var empList = UnitOfWorkAsync.RepositoryAsync<Employee>();


            /* If logged in user is in role Admin then complete result set
            * else filter to map employeeId with logged in person id
            */
            bool isAdmin = false;
            var roleClaims = identity.FindAll(IdentityConstants.ClaimTypes.Role);
            foreach (Claim item in roleClaims)
            {
                if (item.Value == IdentityConstants.Roles.Administrator)
                {
                    isAdmin = true;
                    break;
                }
            }
            if (!isAdmin)
            {
                var person = new Registration.RegistrationController().GetPerson(User.Identity.Name);
                return empList.Query(x => x.ID == person.Id).Select().AsQueryable();
            }

            //var identity = (ClaimsIdentity)User.Identity;
            ////IEnumerable<Claim> claims = ClaimsPrincipal.Current.Claims;

            //var empList = UnitOfWorkAsync.RepositoryAsync<Employee>();

            ///* If logged in user is in role Admin then complete result set
            //* else apply the location filter based on 
            //* locality filter
            //*/

            //var currentRole = identity.FindFirst(IdentityConstants.ClaimTypes.Role).Value;
            //if (currentRole != IdentityConstants.Roles.Administrator)
            //{
            //    //Find location claim
            //    var claim = identity.FindFirst(IdentityConstants.ClaimTypes.Locality).Value;
            //    if (claim != null)
            //    {
            //        return empList.Query(x => x.Location.ToLower() == claim.ToLower()).Select().AsQueryable();
            //    }
            //    else return null;
            //}


            return empList.Queryable();
        }

        [HttpGet]
        [Route("Metadata")]
        public async Task<string> Metadata()
        {
            return await UnitOfWorkAsync.MetaData();
        }

        [HttpPost]
        [Route("SaveChanges")]
        public Task<SaveResult> SaveChanges(JObject saveBundle)
        {
            try
            {
                return UnitOfWorkAsync.SaveChangesAsync(saveBundle);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
