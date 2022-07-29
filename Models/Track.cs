using System.Collections.Generic;

namespace WebApplication.Models
{
    public class Track
    {
        public int IdTrack { get; set; }
        public string TrackName { get; set; }
        public double Duration { get; set; }
        public int? IdMusicAlbum { get; set; }
        public virtual IEnumerable<Musician_Track> Musician_Track  { get; set; }
        public virtual Album Album { get; set; }
    }
}