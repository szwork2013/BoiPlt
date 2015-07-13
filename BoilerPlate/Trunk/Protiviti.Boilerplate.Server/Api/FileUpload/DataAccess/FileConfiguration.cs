using Protiviti.Boilerplate.Server.Api.FileUpload.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace Protiviti.Boilerplate.Server.Api.FileUpload.DataAccess
{
    public class FileConfiguration : EntityTypeConfiguration<File>
    {
        public FileConfiguration()
        {
        }
    }
}