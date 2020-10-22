using System;

namespace FilmArchive.Domain.Models
{
    public class Entry
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime Date { get; set; }
    }
}