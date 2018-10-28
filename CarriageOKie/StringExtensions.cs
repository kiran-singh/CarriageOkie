using System.Collections.Generic;
using System.Linq;

namespace CarriageOKie
{
    public static class StringExtensions
    {
        public static int ToInt(this string input)
        {
            int.TryParse(input, out var result);

            return result;
        }
    }

    public static class ListExtensions
    {
        public static string SongFrom(this IEnumerable<string> songs, int songId)
        {
            var selectedSong = songs.FirstOrDefault(x => x.Contains(songId.ToString()));

            var items = selectedSong.Split('-', '/', '.');
            
            return items[items.Length - 2];
        }
    }
}