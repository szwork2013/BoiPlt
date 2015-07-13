using Breeze.WebApi2;
using System.Threading.Tasks;
using System.Web.Http;

namespace Protiviti.Boilerplate.Server
{
    [BreezeController]
    [RoutePrefix("api")]
    public class MetaDataController : BaseController
    {

        [HttpGet]
        [Route("Metadata")]
        public async Task<string> Get()
        {
            return await UnitOfWorkAsync.MetaData();
        } 
    }
}
