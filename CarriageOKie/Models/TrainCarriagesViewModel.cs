using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CarriageOKie.Models
{
    public class TrainCarriagesViewModel
    {
        public string Train { get; set; }

        public string Carriage { get; set; }
        
        public List<SelectListItem> Trains { get; set; }

        public List<SelectListItem> Carriages { get; set; }

        public IList<GenreSongsViewModel> GenreSongsViewModels { get; set; }
    }

    public class GenreSongsViewModel
    {
        public string Genre { get; set; }

        public List<Song> Songs { get; set; }        
    }

    public class Song
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}