using Protiviti.Boilerplate.Server.Api.FileUpload.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace Protiviti.Boilerplate.Server.Api.FileUpload.DataAccess
{
    [DbConfigurationTypeAttribute(typeof(Configuration.Configuration))]
    public class FileUploadDbContext : DbContext
    {
        public FileUploadDbContext()
            : base(nameOrConnectionString: "FileUploadDbContext")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Entity<File>().ToTable("File", schemaName: "FileUpload");
        }

        public DbSet<File> File { get; set; }

    }
}