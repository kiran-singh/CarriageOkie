using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarriageOKie.Models;
using CarriageOKie.Services;
using Microsoft.AspNetCore.Mvc;

namespace CarriageOKie.Controllers
{
    public class LyricsController : Controller
    {
        private readonly IGenreSongsService _genreSongsService;

        public LyricsController(IGenreSongsService genreSongsService)
        {
            _genreSongsService = genreSongsService;
        }

        /// <summary>
        /// selected song and list of populars
        /// </summary>
        /// <returns>The index.</returns>
        [HttpGet]
        [Route("/lyrics/{trainId}/{carriage}/{song}")]
        public ActionResult Index(int trainId, string carriage, string song)
        {
            return View(_genreSongsService.Get(song));
        }
    }
}