using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Breeze.ContextProvider;
using Breeze.ContextProvider.EF6;
using Breeze.WebApi2;
using Newtonsoft.Json.Linq;
using Protiviti.Boilerplate.Server.Api.Initiatives;

namespace Protiviti.Boilerplate.Server.Api.Initiatives
{
    [BreezeController]
    public class CdsInitiativesController : ApiController
    {
        // Initialize entity framework breeze controller
        readonly EFContextProvider<InitiativeDbContext> _contextProvider =
            new EFContextProvider<InitiativeDbContext>();

        // ~/breeze/CdsInitiatives/Initiatives
        [HttpGet]
        public IQueryable<Initiative> Initiatives()
        {
            return _contextProvider.Context.Initiatives;
        }

        // ~/breeze/CdsInitiatives/InitiativeTasks
        [HttpGet]
        public IQueryable<InitiativeTask> InitiativeTasks()
        {
            return _contextProvider.Context.InitiativeTasks;
        }

        // ~/breeze/CdsInitiatives/Persons
        [HttpGet]
        public IQueryable<Person> Persons()
        {
            return _contextProvider.Context.Persons;
        }

        // ~/breeze/CdsInitiatives/Metadata
        [HttpGet]
        public string Metadata()
        {
            return _contextProvider.Metadata();
        }

        // ~/breeze/CdsInitiatives/SaveChanges
        [HttpPost]
        public SaveResult SaveChanges(JObject saveBundle)
        {
            return _contextProvider.SaveChanges(saveBundle);
        }
    }
}