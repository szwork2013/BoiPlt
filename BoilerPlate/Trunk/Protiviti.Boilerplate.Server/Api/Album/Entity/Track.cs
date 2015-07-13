using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Protiviti.Boilerplate.Server.Api.Album
{
    public class Track
    {
        public string TrackId { get; set; }

        public string SongId { get; set; }
        
        public string ArtistName { get; set; }

        public string SongTitle { get; set; }

        public int SongLength { get; set; }

        public string SongAuthor { get; set; }
    }
}