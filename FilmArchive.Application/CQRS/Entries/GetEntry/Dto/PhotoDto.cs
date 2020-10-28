namespace FilmArchive.Application.CQRS.Entries.GetEntry.Dto
{
    public class PhotoDto
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public CameraDto Camera { get; set; }
        public FilmDto Film { get; set; }
        public int ExposureIndex { get; set; }
        public string Location { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
    }
}