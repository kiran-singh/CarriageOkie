using System.Collections.Generic;

namespace CarriageOKie.Models
{
    public class PopularSongViewModel
    {
        public string Favourite { get; set; }
        public IEnumerable<string> Lyrics { get; set; }
        public string Song { get; set; }
    }
}