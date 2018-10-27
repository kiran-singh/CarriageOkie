using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarriageOKie.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CarriageOKie.Controllers
{
    public class LyricsController : Controller
    {
        /// <summary>
        /// selected song and list of populars
        /// </summary>
        /// <returns>The index.</returns>
        [HttpGet]
        public ActionResult Index()
        {
            string selectedSong = "Song1";
            PopularSongsViewModel vm = new PopularSongsViewModel
            {
                PopularSongsList = new List<PopularSongs>
                {
                    new PopularSongs {ID=1,SongName=selectedSong,IsSelected=false},
                    new PopularSongs {ID=2,SongName="Song2",IsSelected=false},
                    new PopularSongs {ID=3,SongName="Song3",IsSelected=false}

                }
            };
            return View(vm);
        }
    }
}
