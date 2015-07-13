using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Repository.Pattern.Ef6.Factories;

namespace Protiviti.Boilerplate.Server.Api.Initiatives
{
    public class CdsInitiativesDbInitializer : DropCreateDatabaseIfModelChanges<InitiativeDbContext>
    {
        readonly IRepositoryProvider _repositoryProvider = new RepositoryProvider(new RepositoryFactories());
        protected override void Seed(InitiativeDbContext context)
        {
            base.Seed(context);
        }
    }
}