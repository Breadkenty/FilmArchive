using FilmArchive.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace FilmArchive.Persistence.Context
{
    public class FilmArchiveDatabaseContext : DbContext
    {
        public FilmArchiveDatabaseContext(DbContextOptions<FilmArchiveDatabaseContext> options) : base(options)
        {
        }
        public DbSet<Entry> Entries { get; set; }
        public DbSet<Camera> Cameras { get; set; }
        public DbSet<Film> Films { get; set; }
        public DbSet<Photo> Photos { get; set; }
    }
}