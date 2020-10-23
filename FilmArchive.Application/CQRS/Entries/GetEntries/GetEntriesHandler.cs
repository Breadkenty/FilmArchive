using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using FilmArchive.Application.Services;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FilmArchive.Application.CQRS.Entries.GetEntries
{
    public class GetEntriesHandler : IRequestHandler<GetEntriesRequest, IEnumerable<GetEntriesResponse>>
    {
        private readonly IDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetEntriesHandler(IDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<IEnumerable<GetEntriesResponse>> Handle(GetEntriesRequest request, CancellationToken cancellationToken)
        {
            var entries = await _dbContext.Entries
                .Include(entry => entry.Photos)
                    .ThenInclude(photo => photo.Camera)
                .Include(entry => entry.Photos)
                    .ThenInclude(photo => photo.Film)
                .ToListAsync();

            return _mapper.Map<IEnumerable<GetEntriesResponse>>(entries);
        }
    }
}