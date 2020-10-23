using System;
using System.Collections.Generic;

namespace FilmArchive.Domain.Models
{
    public class Entry
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime Date { get; set; }
        public string ThumbnailUrl { get; set; }
        public List<Photo> Photos { get; set; }
    }
}