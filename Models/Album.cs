using System;
using System.Collections.Generic;


namespace WebApplication.Models
{
    public class Album
    {
        public int IdAlbum { get; set; }
        public string AlbumName { get; set; }
        public DateTime PublishDate { get; set; }
        public int IdMusicLabel { get; set; }
        public virtual IEnumerable<Track> Track { get; set; }
        public virtual MusicLabel MusicLabel { get; set; }
    }
}