using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using FilmArchive.Application.Services;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FilmArchive.Application.CQRS.Entries.GetEntry
{
    public class GetEntryHandler : IRequestHandler<GetEntryRequest, GetEntryResponse>
    {
        private readonly IDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetEntryHandler(IDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<GetEntryResponse> Handle(GetEntryRequest request, CancellationToken cancellationToken)
        {
            Console.WriteLine(request.Id);
            var entry = await _dbContext.Entries
                .Where(entry => entry.Id == request.Id)
                .Include(entry => entry.Photos)
                    .ThenInclude(photo => photo.Camera)
                .Include(entry => entry.Photos)
                    .ThenInclude(photo => photo.Film)
                .FirstOrDefaultAsync();

            if (entry == null)
                throw new KeyNotFoundException($"Entry with id {request.Id} does not exist");

            return _mapper.Map<GetEntryResponse>(entry);
        }
    }
}