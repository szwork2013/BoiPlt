using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Protiviti.Boilerplate.Server.Api.ApplicationWizard
{
    public class Invoice
    {
        public int Id { get; set; } 

        public int Amount { get; set; }

        public int PaymentId { get; set; }

        public Payment Payment { get; set; }

        public DateTime SubmitDate { get; set; }
    }
}