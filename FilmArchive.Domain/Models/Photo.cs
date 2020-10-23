namespace FilmArchive.Domain.Models
{
    public class Photo
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public Camera Camera { get; set; }
        public Film Film { get; set; }
        public int ExposureIndex { get; set; }
        public string Location { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
    }
}