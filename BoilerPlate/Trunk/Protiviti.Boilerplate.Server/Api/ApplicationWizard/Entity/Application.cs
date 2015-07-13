using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Protiviti.Boilerplate.Server.Api.ApplicationWizard
{
    public class Application
    {
        public int Id { get; set; }

        public int ApplicantId { get; set; }

        public virtual Applicant Applicant { get; set; }

        public int ProgramId { get; set; }

        public virtual Program Program { get; set; }

        public int InvoiceId { get; set; }

        public virtual Invoice Invoice { get; set; }

        public string Name { get; set; }

        public string Status { get; set; }

        public DateTime SubmittedDate { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime LastChangedDate { get; set; }

    }
}