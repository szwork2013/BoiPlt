using Protiviti.Boilerplate.Server.Api.Employee;
using System.Web.Http;
using System.Threading.Tasks;

namespace Protiviti.Boilerplate.Server
{
    public class BaseController : ApiController
    {
        public async Task<string> BreezeMetadata()
        {
            return await UnitOfWorkAsync.MetaData();
        }

        public IBreezeUnitofWorkAsync UnitOfWorkAsync { get; set; }
    }
}
