using System.Collections.Generic;

namespace FilmArchive.Domain.Models
{
    public class Camera
    {
        public int Id { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public List<Photo> Photos { get; set; }
    }
}