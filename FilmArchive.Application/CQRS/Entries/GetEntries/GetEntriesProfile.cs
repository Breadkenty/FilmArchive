using AutoMapper;
using FilmArchive.Application.CQRS.Entries.GetEntries.Dto;
using FilmArchive.Domain.Models;

namespace FilmArchive.Application.CQRS.Entries.GetEntries
{
    class GetEntriesProfile : Profile
    {
        public GetEntriesProfile()
        {
            CreateMap<Entry, GetEntriesResponse>();
            CreateMap<Photo, PhotoDto>();
            CreateMap<Film, FilmDto>();
            CreateMap<Camera, CameraDto>();
        }

    }
}