using System.Collections.Generic;

namespace FilmArchive.Domain.Models
{
    public class Film
    {
        public int Id { get; set; }
        public string Brand { get; set; }
        public string stock { get; set; }
        public int Iso { get; set; }
        public List<Photo> Photos { get; set; }
    }
}