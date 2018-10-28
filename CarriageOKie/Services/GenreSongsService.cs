using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using CarriageOKie.Models;

namespace CarriageOKie.Services
{
    public interface IGenreSongsService
    {
        IList<GenreSongsViewModel> Get();
        
        PopularSongViewModel Get(string song);
    }

    public class GenreSongsService : IGenreSongsService
    {
        private const string PathSongs = "wwwroot/songs";
        private readonly Random _random = new Random();
        private static readonly List<string> PopularSongs = new List<string>
        {
            "Manic Monday (The Bangles)",
            "Train Of Love (Johnny Cash)",
            "The Weekend (SZA)",
            "Born To Be Wild (Steppenwolf)",
        };

        public IList<GenreSongsViewModel> Get()
        {
            var directories = Directory.GetDirectories(PathSongs);

            var genreSongsViewModels = directories.Select(x => new GenreSongsViewModel
            {
                Genre = x.Replace(PathSongs, null).Replace("/", null),
                Songs = Directory.EnumerateFiles(x, "*.txt").Select(y =>
                {
                    var items = y.Split(new[] {'/', '.'});
                    return items[items.Length - 2];
                }).ToList(),
            }).ToList();
            
            return genreSongsViewModels;
        }

        public PopularSongViewModel Get(string song)
        {
            var favourite = PopularSongs.Contains(song) ? song : PopularSongs[_random.Next(0, PopularSongs.Count)];

            var message = PopularSongs.Contains(song)
                ? $"You chose <b>{song}</b> which is currently most in demand in your train carriage.<br/> If you'd like to sing it please click Lyrics button to get lyrics for the song."
                : $"You chose <emp>{song}</emp> but the current favourite is <b>{favourite}</b> in your train carriage.<br/> If you'd like to sing it please click Lyrics button to see the lyrics for the song.";

            var songs = Directory.EnumerateFiles(PathSongs, "*.txt", SearchOption.AllDirectories);
            var selectedSong =
                songs.FirstOrDefault(x => x.IndexOf(song, StringComparison.CurrentCultureIgnoreCase) >= 0);

            var popularSongViewModel = new PopularSongViewModel
            {
                Lyrics = File.ReadLines(selectedSong),
                Favourite = favourite,
                Song = song,
            };
            
            return popularSongViewModel;
        }
    }
}