using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FilmArchive.Domain.Models;
using FilmArchive.Persistence.Context;
using MediatR;
using FilmArchive.Application.CQRS.Entries.GetEntries;
using FilmArchive.Application.CQRS.Entries.GetEntry;

namespace FilmArchive.WebUI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EntriesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public EntriesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/Entries
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetEntriesResponse>>> GetEntries()
        {
            var query = new GetEntriesRequest();
            var result = await _mediator.Send(query);

            return Ok(result);
        }

        // GET: api/Entries/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GetEntryResponse>> GetEntry(int id)
        {
            var query = new GetEntryRequest { Id = id };
            var result = await _mediator.Send(query);

            return Ok(result);
        }

        // // PUT: api/Entries/5
        // // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        // [HttpPut("{id}")]
        // public async Task<IActionResult> PutEntry(int id, Entry entry)
        // {
        //     if (id != entry.Id)
        //     {
        //         return BadRequest();
        //     }

        //     _context.Entry(entry).State = EntityState.Modified;

        //     try
        //     {
        //         await _context.SaveChangesAsync();
        //     }
        //     catch (DbUpdateConcurrencyException)
        //     {
        //         if (!EntryExists(id))
        //         {
        //             return NotFound();
        //         }
        //         else
        //         {
        //             throw;
        //         }
        //     }

        //     return NoContent();
        // }

        // // POST: api/Entries
        // // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        // [HttpPost]
        // public async Task<ActionResult<Entry>> PostEntry(Entry entry)
        // {
        //     _context.Entries.Add(entry);
        //     await _context.SaveChangesAsync();

        //     return CreatedAtAction("GetEntry", new { id = entry.Id }, entry);
        // }

        // // DELETE: api/Entries/5
        // [HttpDelete("{id}")]
        // public async Task<ActionResult<Entry>> DeleteEntry(int id)
        // {
        //     var entry = await _context.Entries.FindAsync(id);
        //     if (entry == null)
        //     {
        //         return NotFound();
        //     }

        //     _context.Entries.Remove(entry);
        //     await _context.SaveChangesAsync();

        //     return entry;
        // }

        // private bool EntryExists(int id)
        // {
        //     return _context.Entries.Any(e => e.Id == id);
        // }
    }
}
