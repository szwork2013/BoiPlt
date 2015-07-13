using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Protiviti.Boilerplate.Server.Api.ApplicationWizard
{
    public class Payment
    {
        public int Id { get; set; } 

        public int Type { get; set; }

        public string AccountNumber { get; set; }

        public string RoutingNumber { get; set; }

        public DateTime PaymentDate { get; set; }
    }
}