using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using System.Web.Http.OData;
using System.Web.Http.OData.Routing;

namespace Protiviti.Boilerplate.Server.Api.ApplicationWizard
{
    public class ApplicationsController : ODataController
    {
        private ApplicationWizardContext db = new ApplicationWizardContext();

        // GET: odata/Applications
        [EnableQuery]
        public IQueryable<Application> GetApplications()
        {
            return db.Applications;
        }

        // GET: odata/Applications(5)
        [EnableQuery]
        public SingleResult<Application> GetApplication([FromODataUri] int key)
        {
            return SingleResult.Create(db.Applications.Where(application => application.Id == key));
        }

        // PUT: odata/Applications(5)
        public IHttpActionResult Put([FromODataUri] int key, Delta<Application> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Application application = db.Applications.Find(key);
            if (application == null)
            {
                return NotFound();
            }

            patch.Put(application);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ApplicationExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(application);
        }

        // POST: odata/Applications
        public IHttpActionResult Post(Application application)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Applications.Add(application);
            db.SaveChanges();

            return Created(application);
        }

        // PATCH: odata/Applications(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public IHttpActionResult Patch([FromODataUri] int key, Delta<Application> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Application application = db.Applications.Find(key);
            if (application == null)
            {
                return NotFound();
            }

            patch.Patch(application);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ApplicationExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(application);
        }

        // DELETE: odata/Applications(5)
        public IHttpActionResult Delete([FromODataUri] int key)
        {
            Application application = db.Applications.Find(key);
            if (application == null)
            {
                return NotFound();
            }

            db.Applications.Remove(application);
            db.SaveChanges();

            return StatusCode(HttpStatusCode.NoContent);
        }

        // GET: odata/Applications(5)/Applicant
        [EnableQuery]
        public SingleResult<Applicant> GetApplicant([FromODataUri] int key)
        {
            return SingleResult.Create(db.Applications.Where(m => m.Id == key).Select(m => m.Applicant));
        }

        // GET: odata/Applications(5)/Invoice
        [EnableQuery]
        public SingleResult<Invoice> GetInvoice([FromODataUri] int key)
        {
            return SingleResult.Create(db.Applications.Where(m => m.Id == key).Select(m => m.Invoice));
        }

        // GET: odata/Applications(5)/Program
        [EnableQuery]
        public SingleResult<Program> GetProgram([FromODataUri] int key)
        {
            return SingleResult.Create(db.Applications.Where(m => m.Id == key).Select(m => m.Program));
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ApplicationExists(int key)
        {
            return db.Applications.Count(e => e.Id == key) > 0;
        }
    }
}
