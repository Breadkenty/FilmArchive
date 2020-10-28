namespace FilmArchive.Application.CQRS.Entries.GetEntry.Dto
{
    public class FilmDto
    {
        public int Id { get; set; }
        public string Brand { get; set; }
        public string stock { get; set; }
        public int Iso { get; set; }
        public string Size { get; set; }
    }
}