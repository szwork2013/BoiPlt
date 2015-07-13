using Repository.Pattern.Ef6;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Protiviti.Boilerplate.Server.Api.Employee
{
    public class Employee : Entity
    {
        public int ID { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "First name cannot be longer than 50 characters.")]
        [Column("FirstName")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Full Name")]
        public string FullName
        {
            get
            {
                return LastName + ", " + FirstName;
            }
        }

        public string Location { get; set; }

        public int DivisionID { get; set; }

        public bool IsActive { get; set; }

        public int DesignationID { get; set; }
        public virtual Division Division { get; set; }
        public virtual Designation Designation { get; set; }

    }
}