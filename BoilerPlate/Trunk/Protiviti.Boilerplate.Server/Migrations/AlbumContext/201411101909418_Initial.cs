namespace Protiviti.Boilerplate.Server.Migrations.AlbumContext
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "Album.Tracks",
                c => new
                    {
                        TrackId = c.String(nullable: false, maxLength: 128),
                        SongId = c.String(),
                        ArtistName = c.String(),
                        SongTitle = c.String(),
                    })
                .PrimaryKey(t => t.TrackId);
            
        }
        
        public override void Down()
        {
            DropTable("Album.Tracks");
        }
    }
}
