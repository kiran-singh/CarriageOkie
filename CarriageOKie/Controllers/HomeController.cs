using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using CarriageOKie.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CarriageOKie.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View(new TrainCarriagesViewModel
            {
                Trains = new List<SelectListItem>
                {
                    new SelectListItem{Text = "Birmingham", Value = "1045"},
                    new SelectListItem{Text = "Brighton", Value = "1732"},
                    new SelectListItem{Text = "London", Value = "2798"},
                    new SelectListItem{Text = "Leeds", Value = "4526"},
                    new SelectListItem{Text = "Newcastle", Value = "5234"},
                },
                Carriages = new List<SelectListItem>
                {
                    new SelectListItem{Text = "A", Value = "A"},
                    new SelectListItem{Text = "B", Value = "B"},
                    new SelectListItem{Text = "C", Value = "C"},
                },
                GenreSongsViewModels = new List<GenreSongsViewModel>
                {
                    new GenreSongsViewModel
                    {
                        Genre = "Ballads",
                        Songs = new List<string>
                        {
                            "Come See About Me",
                            "I'll Never Love Again",
                            "The End of Love",
                            "Trip",
                            "Who Hurt You?",
                        }
                    },
                    new GenreSongsViewModel
                    {
                        Genre = "Rock",
                        Songs = new List<string>
                        {
                            "Crawling",
                            "Iris",
                            "Papercut",
                            "Somewhere I belong",
                            "What I've done",
                        }
                    },
                    new GenreSongsViewModel
                    {
                        Genre = "Techno",
                        Songs = new List<string>
                        {
                            "ASCENTION",
                            "ERUPTION",
                            "DISRUPTION",
                            "GUEDE (ARTBAT RAVE MIX)",
                            "THE HATCHET",
                        }
                    }
                }
            });
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
        }
    }
}