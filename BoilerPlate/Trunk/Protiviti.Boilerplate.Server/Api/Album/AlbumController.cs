using Breeze.ContextProvider;
using Breeze.ContextProvider.EF6;
using Breeze.WebApi2;
using Newtonsoft.Json.Linq;
using System.Linq;
using System.Web.Http;

namespace Protiviti.Boilerplate.Server.Api.Album
{
    [BreezeController]
    public class AlbumController : ApiController
    {
        // Initialize entity framework breeze controller
        private EFContextProvider<AlbumContext> _contextProvider;

        public AlbumController(EFContextProvider<AlbumContext> contextProvider)
        {
            this._contextProvider = contextProvider;
        }

        // ~/breeze/Album/Tracks
        [HttpGet]
        public IQueryable<Track> Tracks()
        {
            // http://localhost/Protiviti.Boilerplate.Server/breeze/Album/Tracks
            // http://localhost/Protiviti.Boilerplate.Server/breeze/Album/Tracks?%skip=25&$top=25
            return _contextProvider.Context.Tracks;
        }

        // ~/breeze/Album/Metadata
        [HttpGet]
        public string Metadata()
        {
            return _contextProvider.Metadata();
        }

        // ~/breeze/Album/SaveChanges
        [HttpPost]
        public SaveResult SaveChanges(JObject saveBundle)
        {
            return _contextProvider.SaveChanges(saveBundle);
        }
    }
}