namespace FilmArchive.Application.CQRS.Entries.GetEntries.Dto
{
    public class CameraDto
    {
        public int Id { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
    }
}