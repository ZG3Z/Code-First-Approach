using System;
using System.Collections.Generic;

namespace WebApplication.Models
{
    public class AlbumDto
    {   
            public string AlbumName { get; set; }
            public DateTime PublishDate { get; set; }
            public List<MusicTrackDto> MusicTrack { get; set; }
    }

    public class MusicTrackDto
    {
        public string Name { get; set; }
    }
}