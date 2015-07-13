using Breeze.ContextProvider.EF6;
using Protiviti.Boilerplate.Server.Api.FileUpload.DataAccess;
using Protiviti.Boilerplate.Server.Api.FileUpload.Entity;
using System;
using System.Linq;
using System.Collections.Generic;
using System.IO;
using System.Web;
using System.Web.Http;
using System.Data.Linq;
using Breeze.ContextProvider.EF6;
using System.Net.Http;
using System.Net;
using System.Net.Http.Headers;
using Protiviti.Boilerplate.Server.Logging;
using Breeze.WebApi2;
using System.Threading.Tasks;

namespace Protiviti.Boilerplate.Server.Api.FileUpload
{
    [SlabLoggingFilter]
    [BreezeController]
    [RoutePrefix("api/file")]
    public class FileController : BaseController
    {
        private EFContextProvider<FileUploadDbContext> _contextProvider = new EFContextProvider<FileUploadDbContext>();
        private FileUploadDbContext _fileContext = new FileUploadDbContext();

        [HttpGet]
        [Route("Metadata")]
        public async Task<string> Metadata()
        {
            return await UnitOfWorkAsync.MetaData();
        }


        [HttpPost]
        [Route("UploadFile")]
        public IHttpActionResult UploadFile(List<Protiviti.Boilerplate.Server.Api.FileUpload.Entity.File> files)
        {
            try
            {
                foreach (var file in files)
                {
                    if (file.FileImage != null && file.FileType != null)
                    {
                        AddFileToDb(file);
                    }
                }

                //saving here to minimize db hits
                _fileContext.SaveChanges();

                return Ok();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void AddFileToDb(Protiviti.Boilerplate.Server.Api.FileUpload.Entity.File file)
        {                
                file.CreatedDate = DateTime.UtcNow;
                file.CreatedPersonId = 1;

                file.LastChangeDate = DateTime.UtcNow;
                file.LastChangePersonId = 1;
               
                _fileContext.File.Attach((file));
                _fileContext.Entry(file).State = System.Data.Entity.EntityState.Added;
        }

        [HttpGet]
        [Route("GetUploadedFiles")]
        public IQueryable<Protiviti.Boilerplate.Server.Api.FileUpload.Entity.File> GetUploadedFiles()
        {
            return _contextProvider.Context.File;
        }

        [HttpGet]
        [Route("Download")]
        public HttpResponseMessage Download(int fileId)
        {
            Protiviti.Boilerplate.Server.Api.FileUpload.Entity.File viewFile = _contextProvider.Context.File.FirstOrDefault(x => x.Id == fileId);
                HttpResponseMessage result = new HttpResponseMessage(HttpStatusCode.OK);
                var stream = new MemoryStream(viewFile.FileImage);
                result.Content = new StreamContent(stream);
               viewFile.FileType = "application/octet-stream";
                result.Content.Headers.ContentType = new MediaTypeHeaderValue(viewFile.FileType);
                result.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment")
                {
                    FileName = viewFile.FileName
                };
                return result;
        }

        [HttpPost]
        [Route("DeleteFile")]
        public void DeleteFile(int id)
        {
            var file = _contextProvider.Context.File.Where(x => x.Id == id).FirstOrDefault();
            var fileContext = new FileUploadDbContext();
            fileContext.File.Attach((file));
            fileContext.Entry(file).State = System.Data.Entity.EntityState.Deleted;

            fileContext.SaveChanges();
        }

        [HttpPost]
        [Route("EditFile")]
        public void EditFile(Protiviti.Boilerplate.Server.Api.FileUpload.Entity.File editedFile)
        {
            var file = _contextProvider.Context.File.Where(x => x.Id == editedFile.Id).FirstOrDefault();

            file.FileName = editedFile.FileName;
            file.Title = editedFile.Title;

            var fileContext = new FileUploadDbContext();
            fileContext.File.Attach((file));
            fileContext.Entry(file).State = System.Data.Entity.EntityState.Modified;

            fileContext.SaveChanges();
        }
    }
}