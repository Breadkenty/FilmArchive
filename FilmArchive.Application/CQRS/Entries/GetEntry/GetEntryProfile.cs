using AutoMapper;
using FilmArchive.Application.CQRS.Entries.GetEntry.Dto;
using FilmArchive.Domain.Models;

namespace FilmArchive.Application.CQRS.Entries.GetEntry
{
    class GetEntryProfile : Profile
    {
        public GetEntryProfile()
        {
            CreateMap<Entry, GetEntryResponse>();
            CreateMap<Photo, PhotoDto>();
            CreateMap<Film, FilmDto>();
            CreateMap<Camera, CameraDto>();
        }

    }
}