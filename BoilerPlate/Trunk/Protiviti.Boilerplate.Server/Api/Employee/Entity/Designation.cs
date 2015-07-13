using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using Repository.Pattern.Ef6;

namespace Protiviti.Boilerplate.Server.Api.Employee
{

    public class Designation : Entity
    {
        public int DesignationID { get; set; }
        
        [Required(AllowEmptyStrings = false, ErrorMessage = "Designation Name is required")]
        [StringLength(20, ErrorMessage = "The {0} must be at least {5} characters long.", MinimumLength = 5)]
        [DataType(DataType.Text)]
        [Display(Name="Designation")]
        public string DesignationName { get; set; }

        public bool IsActive { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
    }
}
