using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Protiviti.Boilerplate.Server.Api.Album
{
    [DbConfigurationTypeAttribute(typeof(Configuration.CacheConfiguration))]
    public class AlbumContext : DbContext
    {
        public AlbumContext() : base("name=AlbumContext")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Entity<Track>().ToTable("Tracks", schemaName: "Album");
        }

        public DbSet<Track> Tracks { get; set; }
    }
}