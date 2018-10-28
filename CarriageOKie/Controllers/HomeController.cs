using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using CarriageOKie.Models;
using CarriageOKie.Services;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CarriageOKie.Controllers
{
    public class HomeController : Controller
    {
        private readonly IGenreSongsService _genreSongsService;

        public HomeController(IGenreSongsService genreSongsService)
        {
            _genreSongsService = genreSongsService;
        }

        public IActionResult Index()
        {
            return View(new TrainCarriagesViewModel
            {
                Trains = new List<SelectListItem>
                {
                    new SelectListItem {Text = "Birmingham", Value = "1045"},
                    new SelectListItem {Text = "Brighton", Value = "1732"},
                    new SelectListItem {Text = "London", Value = "2798"},
                    new SelectListItem {Text = "Leeds", Value = "4526"},
                    new SelectListItem {Text = "Newcastle", Value = "5234"},
                },
                Carriages = new List<SelectListItem>
                {
                    new SelectListItem {Text = "A", Value = "A"},
                    new SelectListItem {Text = "B", Value = "B"},
                    new SelectListItem {Text = "C", Value = "C"},
                },
                GenreSongsViewModels = _genreSongsService.Get(),
            });
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
        }
    }
}