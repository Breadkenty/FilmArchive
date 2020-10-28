using System.Collections.Generic;
using MediatR;

namespace FilmArchive.Application.CQRS.Entries.GetEntry
{
    public class GetEntryRequest : IRequest<GetEntryResponse>
    {
        public int Id { get; set; }
    }
}