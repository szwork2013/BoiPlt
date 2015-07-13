namespace Protiviti.Boilerplate.Server.Migrations.AlbumContext
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedSongLength : DbMigration
    {
        public override void Up()
        {
            AddColumn("Album.Tracks", "SongLength", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("Album.Tracks", "SongLength");
        }
    }
}
