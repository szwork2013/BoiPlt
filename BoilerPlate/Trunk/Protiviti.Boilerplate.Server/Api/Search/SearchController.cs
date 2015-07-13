using Breeze.WebApi2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Protiviti.Boilerplate.Server.Api.Search
{
    [BreezeController]
    public class SearchController : ApiController
    {
        //http://localhost/Protiviti.Boilerplate.Server/breeze/Search/Search/?query=sharp
        //http://localhost/Protiviti.Boilerplate.Server/breeze/Search/Search/?query=online
        [HttpGet]
        public IEnumerable<SearchResult> Search(string query)
        {
            return FullTextSearch.Execute(query);
        }

        //http://localhost/Protiviti.Boilerplate.Server/breeze/Search/SearchResults/?$filter=sharp
        //http://localhost/Protiviti.Boilerplate.Server/breeze/Search/SearchResults/?$filter=online
        [HttpGet]
        public IEnumerable<SearchResult> SearchResults()
        {
            return FullTextSearch.Execute(Request.RequestUri.ParseQueryString().Get("$filter"));
        }
    }
}
