namespace Protiviti.Boilerplate.Server.Migrations.AlbumContext
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Protiviti.Boilerplate.Server.Api.Album.AlbumContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            MigrationsDirectory = @"Migrations\AlbumContext";
        }

        protected override void Seed(Protiviti.Boilerplate.Server.Api.Album.AlbumContext context)
        {
        }
    }
}
