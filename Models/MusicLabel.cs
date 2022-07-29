using System.Collections.Generic;

namespace WebApplication.Models
{
    public class MusicLabel
    {
        public int IdMusicLabel { get; set; }
        public string Name { get; set; }
        public virtual IEnumerable<Album> Album { get; set; }
    }
}