using Breeze.ContextProvider;
using Breeze.ContextProvider.EF6;
using Newtonsoft.Json.Linq;
using Repository.Pattern.DataContext;
using Repository.Pattern.Ef6.Factories;
using Repository.Pattern.Infrastructure;
using Repository.Pattern.Repositories;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Threading.Tasks;

namespace Protiviti.Boilerplate.Server.Api.Employee
{

    public interface IBreezeUnitofWorkAsync
    {
        void BeginTransaction(IsolationLevel isolationLevel = IsolationLevel.Unspecified);
        bool Commit();
        DbContext DbContext();
        Task<string> MetaData();
        IRepositoryAsync<TEntity> RepositoryAsync<TEntity>() where TEntity : class, IObjectState;
        void Rollback();
        Task<SaveResult> SaveChangesAsync(JObject saveBundle);
    }

    public class ProtivitiContextProvider<T> : EFContextProvider<T>, IBreezeUnitofWorkAsync where T : class, new()
    {

        public ProtivitiContextProvider(IRepositoryProvider repositoryProvider)
        {
            RepositoryProvider = repositoryProvider;
            RepositoryProvider.DataContext = (IDataContextAsync)base.Context;
        }

        private IDbTransaction _transaction;

        public new void BeginTransaction(IsolationLevel isolationLevel = IsolationLevel.Unspecified)
        {
            _transaction = base.BeginTransaction(isolationLevel);
        }

        public bool Commit()
        {
            _transaction.Commit();
            return true;
        }

        public DbContext DbContext()
        {
            return (DbContext)(IObjectContextAdapter)base.ObjectContext;
        }


        public async Task<string> MetaData()
        {
            return await Task.Run(() => base.Metadata());
        }

        public IRepositoryAsync<TEntity> RepositoryAsync<TEntity>() where TEntity : class, IObjectState
        {
            return RepositoryProvider.GetRepositoryForEntityType<TEntity>();
        }

        public void Rollback()
        {
            _transaction.Rollback();
        }

        public async Task<SaveResult> SaveChangesAsync(JObject saveBundle)
        {
            return await Task.Run(() => base.SaveChanges(saveBundle));
        }

        protected IRepositoryProvider RepositoryProvider { get; set; }
    }
}