namespace Protiviti.Boilerplate.Server.Migrations.AlbumContext
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedSongAuthor : DbMigration
    {
        public override void Up()
        {
            AddColumn("Album.Tracks", "SongAuthor", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("Album.Tracks", "SongAuthor");
        }
    }
}
