using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Protiviti.Boilerplate.Server.Api.ApplicationWizard
{
    public class Applicant
    {
        public int Id { get; set; } 

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string CompanyName { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public string Department { get; set; }

        public string Track { get; set; }

    }
}