Group Entities by Database Schema
=

In EF Database Context class, override OnModelCreating method and add a call to "modelBuilder.Entity" for the entity that you want to override schema name. 

See an example below where Tracks entity is stored in Album database schema:

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


This approach provides the most flexibility when you have to re-use an entity across applications and still have them stored in application specific schema. Let us discuss this point with an example. Say we are building multiple applications for a client that require invoice entity, also invoice entity properties and database constraints are same across applications. But, client does not want to store invoices from these applications together. So, what we will do is we will develop a common invoice entity but create one Database Context per application. We will also specify different database schema in these contexts. This way we are able to re-use invoice entity but still store invoices by application. In addition, we can easily store these invoice tables in separate database partitions for potentially higher performance.


Alternatively, you can decorate your model configuration class or model class with schema name attributes but these approches are not as flexible as described above.

<p class="updated">Updated on 12/15/2014 by Alok Gupta</p>
<p class="reviewed">Reviewed on 12/15/2014 by Alok Gupta</p>

















