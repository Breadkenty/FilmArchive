namespace FilmArchive.Domain.Models
{
    public class Photo
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public Camera Camera { get; set; }
        public Film Film { get; set; }
        public int ExposureIndex { get; set; }

    }
}