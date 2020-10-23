using System.Collections.Generic;
using MediatR;

namespace FilmArchive.Application.CQRS.Entries.GetEntries
{
    public class GetEntriesRequest : IRequest<IEnumerable<GetEntriesResponse>>
    {

    }
}