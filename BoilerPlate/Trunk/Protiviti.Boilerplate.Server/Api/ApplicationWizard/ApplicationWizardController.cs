using Breeze.ContextProvider;
using Breeze.ContextProvider.EF6;
using Breeze.WebApi2;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace Protiviti.Boilerplate.Server.Api.ApplicationWizard
{
    [BreezeController]
    public class ApplicationWizardController : ApiController
    {
        // Initialize entity framework breeze controller
        private EFContextProvider<ApplicationWizardContext> _contextProvider;

        public ApplicationWizardController(EFContextProvider<ApplicationWizardContext> contextProvider)
        {
            this._contextProvider = contextProvider;
        }

        // ~/breeze/ApplicationWizard/Applications
        [HttpGet]
        public IQueryable<Application> Applications()
        {
            return _contextProvider.Context.Applications;
        }

        // ~/breeze/ApplicationWizard/Programs
        [HttpGet]
        public IQueryable<Program> Programs()
        {
            // http://localhost/Protiviti.Boilerplate.Server/breeze/ApplicationWizard/Programs?%skip=2&$top=2
            // http://localhost/Protiviti.Boilerplate.Server/breeze/ApplicationWizard/Programs?%skip=2&$top=5&$orderby=Name
            // http://localhost/Protiviti.Boilerplate.Server/breeze/ApplicationWizard/Programs?%skip=2&$top=5&$orderby=Name desc
            // http://localhost/Protiviti.Boilerplate.Server/breeze/ApplicationWizard/Programs?%skip=2&$top=5&$orderby=Name%20desc&$filter=Cost%20gt%20400
            return _contextProvider.Context.Programs;
        }

        // ~/breeze/ApplicationWizard/ApplicationsWithTotalItemsCount
        [HttpGet]
        public HttpResponseMessage ApplicationsWithTotalItemsCount()
        {
            var result = new
            {
                total = _contextProvider.Context.Applications.Count(),
                data = _contextProvider.Context.Applications.OrderBy(a => a.Name)
                    .Include(a => a.Program)
                    .Include(a => a.Applicant)
                    .Include(a => a.Invoice.Payment)
                    .Skip(int.Parse(Request.RequestUri.ParseQueryString().Get("skip")))
                    .Take(int.Parse(Request.RequestUri.ParseQueryString().Get("take"))).ToList()
            };
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        // ~/breeze/ApplicationWizard/Metadata
        [HttpGet]
        public string Metadata()
        {
            return _contextProvider.Metadata();
        }

        // ~/breeze/ApplicationWizard/SaveChanges
        [HttpPost]
        public SaveResult SaveChanges(JObject saveBundle)
        {
            return _contextProvider.SaveChanges(saveBundle);
        }
    }
}