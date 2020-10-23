namespace FilmArchive.Application.CQRS.Entries.GetEntries.Dto
{
    public class PhotoDto
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public CameraDto Camera { get; set; }
        public FilmDto Film { get; set; }
        public int ExposureIndex { get; set; }
    }
}