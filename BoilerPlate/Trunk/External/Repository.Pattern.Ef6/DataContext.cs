using System;
using System.Data.Entity;
using System.Threading;
using System.Threading.Tasks;
using Repository.Pattern.DataContext;
using Repository.Pattern.Infrastructure;

namespace Repository.Pattern.Ef6
{
    public class DataContext : DbContext, IDataContextAsync
    {
        #region Private Fields
        private readonly Guid _instanceId;
        bool _disposed;
        #endregion Private Fields

        public DataContext(string nameOrConnectionString) : base(nameOrConnectionString)
        {
            _instanceId = Guid.NewGuid();
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;
        }

        public Guid InstanceId { get { return _instanceId; } }

        public override int SaveChanges()
        {
            SyncObjectsStatePreCommit();
            var changes = base.SaveChanges();
            SyncObjectsStatePostCommit();
            return changes;
        }

        public override async Task<int> SaveChangesAsync()
        {
            SyncObjectsStatePreCommit();
            var changesAsync = await base.SaveChangesAsync();
            SyncObjectsStatePostCommit();
            return changesAsync;
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        {
            SyncObjectsStatePreCommit();
            var changesAsync = await base.SaveChangesAsync(cancellationToken);
            SyncObjectsStatePostCommit();
            return changesAsync;
        }

        public void SyncObjectState(object entity) { Entry(entity).State = StateHelper.ConvertState(((IObjectState)entity).ObjectState); }
        public new DbSet<T> Set<T>() where T : class { return base.Set<T>(); }

        private void SyncObjectsStatePreCommit()
        {
            // Comment out this below code because of conflict with Breeze

            //foreach (var dbEntityEntry in ChangeTracker.Entries())
            //{
            //    dbEntityEntry.State = StateHelper.ConvertState(((IObjectState)dbEntityEntry.Entity).ObjectState);
            //}
        }

        public void SyncObjectsStatePostCommit()
        {
            // Comment out this below code because of conflict with Breeze

            //foreach (var dbEntityEntry in ChangeTracker.Entries())
            //{
            //    ((IObjectState)dbEntityEntry.Entity).ObjectState = StateHelper.ConvertState(dbEntityEntry.State);
            //}
        }

        protected override void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    // free other managed objects that implement
                    // IDisposable only
                }

                // release any unmanaged objects
                // set object references to null

                _disposed = true;
            }

            base.Dispose(disposing);
        }
    }
}