using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using Repository.Pattern.Ef6;

namespace Protiviti.Boilerplate.Server.Api.FileUpload.Entity
{
    public class File 
    {        
        [Key]
        public int Id { get; set; }

        public string Title { get; set; }

        public string FileName { get; set; }
                
        public byte[] FileImage { get; set; }

        public string FileType { get; set; }

        public double FileSize { get; set; }

        #region created 
        public System.DateTime CreatedDate { get; set; }

        public int CreatedPersonId { get; set; }
        #endregion

        #region last changes
        public System.DateTime LastChangeDate { get; set; }

        public int LastChangePersonId { get; set; }
        #endregion

    }
}