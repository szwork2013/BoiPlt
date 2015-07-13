using EFCache;
using System.Data.Entity;
using System.Data.Entity.Core.Common;

namespace Protiviti.Boilerplate.Server.Configuration
{
    /// <summary>
    /// Cache Configuration Class
    /// </summary>
    public class CacheConfiguration : Configuration
    {
        internal static readonly InMemoryCache Cache = new InMemoryCache();

        /// <summary>
        /// Constructor 
        /// </summary>
        public CacheConfiguration()
        {
            var transactionHandler = new CacheTransactionHandler(Cache);

            AddInterceptor(transactionHandler);

            Loaded += (sender, args) => args.ReplaceService<DbProviderServices>
                (
                    (s, _) => new CachingProviderServices(s, transactionHandler, new CachingPolicy())
                );
        }
    }
}