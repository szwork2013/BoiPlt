using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Protiviti.Boilerplate.Server.Api.Search
{
    public class SearchResult
    {
        public int EntityId { get; set; }

        public string EntityTypeName { get; set; }

        public string SearchTitle { get; set; }

        public string SearchBody { get; set; }
    }
}