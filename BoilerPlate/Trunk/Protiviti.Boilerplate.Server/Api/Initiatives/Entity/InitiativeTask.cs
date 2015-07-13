using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Protiviti.Boilerplate.Server.Api.Initiatives
{
    public class InitiativeTask
    {
        public int Id { get; set; }
        public int InitiativeId { get; set; }
        [Required, MaxLength(30)]
        public string TaskName { get; set; }
        public int ContactId { get; set; }
        public string Description { get; set; }
        [Url]
        public string Url { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        public virtual Initiative Initiative { get; set; }
        public virtual Person Contact { get; set; }

    }
}