using System.Collections.Generic;

namespace WebApplication.Models
{
    public class Musician
    {
        public int IdMusician { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? NickName { get; set; }
        public virtual IEnumerable<Musician_Track> Musician_Track { get; set; }
    }
}