using System;
using System.Collections.Generic;
using FilmArchive.Application.CQRS.Entries.GetEntries.Dto;

namespace FilmArchive.Application.CQRS.Entries.GetEntries
{
    public class GetEntriesResponse
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime Date { get; set; }
        public string ThumbnailUrl { get; set; }
        public List<PhotoDto> Photos { get; set; }
        public string Notes { get; set; }
    }
}