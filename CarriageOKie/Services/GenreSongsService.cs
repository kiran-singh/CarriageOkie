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
        
        PopularSongViewModel Get(int songId);
    }

    public class GenreSongsService : IGenreSongsService
    {
        private const string PathSongs = "wwwroot/songs";
        private readonly Random _random = new Random();
        private static readonly List<int> PopularSongsIds = new List<int>
        {
            209273,
            306354,
            503751,
            805869,
        };

        public IList<GenreSongsViewModel> Get()
        {
            var directories = Directory.GetDirectories(PathSongs);

            var genreSongsViewModels = directories.Select(x => new GenreSongsViewModel
            {
                Genre = x.Replace(PathSongs, null).Replace("/", null),
                Songs = Directory.EnumerateFiles(x, "*.txt").Select(y =>
                {
                    var items = y.Split('-', '/', '.');
                    return new Song
                    {
                        Id = items[items.Length - 3].ToInt(),
                        Name = items[items.Length - 2]
                    };
                }).ToList(),
            }).OrderBy(x => x.Genre).ToList();
            
            return genreSongsViewModels;
        }

        public PopularSongViewModel Get(int songId)
        {
            var favourite = PopularSongsIds.Contains(songId)
                ? songId
                : PopularSongsIds[_random.Next(0, PopularSongsIds.Count)];

            var songs = Directory.EnumerateFiles(PathSongs, "*.txt", SearchOption.AllDirectories).ToList();
            
            var selectedSong = songs.FirstOrDefault(x => x.Contains(favourite.ToString()));

            var popularSongViewModel = new PopularSongViewModel
            {
                Lyrics = File.ReadLines(selectedSong),
                Favourite = songs.SongFrom(favourite),
                Song = songs.SongFrom(songId),
            };
            
            return popularSongViewModel;
        }
    }
}