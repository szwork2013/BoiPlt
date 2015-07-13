using Repository.Pattern.Ef6;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Protiviti.Boilerplate.Server.Api.Employee
{
    public class Division: Entity
    {
        public int DivisionID { get; set; }

        [StringLength(50, MinimumLength = 3)]
        public string Name { get; set; }

        [StringLength(30, MinimumLength = 5)]

        public virtual ICollection<Employee> Employees { get; set; }
    }
}