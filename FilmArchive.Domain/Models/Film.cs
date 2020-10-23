using System.Collections.Generic;

namespace FilmArchive.Domain.Models
{
    public class Film
    {
        public int Id { get; set; }
        public string Brand { get; set; }
        public string Stock { get; set; }
        public int Iso { get; set; }
        public string Size { get; set; }
        public List<Photo> Photos { get; set; }
    }
}