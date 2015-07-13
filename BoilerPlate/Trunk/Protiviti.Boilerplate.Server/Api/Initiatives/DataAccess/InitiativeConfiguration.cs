using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity;

namespace Protiviti.Boilerplate.Server.Api.Initiatives
{
    public class InitiativeConfiguration : EntityTypeConfiguration<Initiative>
    {
        public InitiativeConfiguration()
        {
            ToTable("CdsInitiative.Initiative");
        }
    }
}