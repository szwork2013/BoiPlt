using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Protiviti.Boilerplate.Server.Api.Initiatives
{
    public class Initiative
    {
        public int Id { get; set; }
        [Required, MaxLength(50)]
        public string Name { get; set; }

        public virtual ICollection<InitiativeTask> Tasks { get; set; } 
    }
}