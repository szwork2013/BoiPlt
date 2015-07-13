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
    public class ProgramsController : ODataController
    {
        private ApplicationWizardContext db = new ApplicationWizardContext();

        // GET: odata/Programs
        [EnableQuery]
        public IQueryable<Program> GetPrograms()
        {
            // http://localhost/Protiviti.Boilerplate.Server/odata/Programs?$skip=3
            // http://localhost/Protiviti.Boilerplate.Server/odata/Programs?$skip=3&$top=2
            return db.Programs;
        }

        // GET: odata/Programs(5)
        [EnableQuery]
        public SingleResult<Program> GetProgram([FromODataUri] int key)
        {
            return SingleResult.Create(db.Programs.Where(program => program.Id == key));
        }

        // PUT: odata/Programs(5)
        public IHttpActionResult Put([FromODataUri] int key, Delta<Program> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Program program = db.Programs.Find(key);
            if (program == null)
            {
                return NotFound();
            }

            patch.Put(program);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProgramExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(program);
        }

        // POST: odata/Programs
        public IHttpActionResult Post(Program program)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Programs.Add(program);
            db.SaveChanges();

            return Created(program);
        }

        // PATCH: odata/Programs(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public IHttpActionResult Patch([FromODataUri] int key, Delta<Program> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Program program = db.Programs.Find(key);
            if (program == null)
            {
                return NotFound();
            }

            patch.Patch(program);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProgramExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(program);
        }

        // DELETE: odata/Programs(5)
        public IHttpActionResult Delete([FromODataUri] int key)
        {
            Program program = db.Programs.Find(key);
            if (program == null)
            {
                return NotFound();
            }

            db.Programs.Remove(program);
            db.SaveChanges();

            return StatusCode(HttpStatusCode.NoContent);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ProgramExists(int key)
        {
            return db.Programs.Count(e => e.Id == key) > 0;
        }
    }
}
