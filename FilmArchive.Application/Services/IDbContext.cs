using System.Diagnostics.CodeAnalysis;
using System.Threading;
using System.Threading.Tasks;
using FilmArchive.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace FilmArchive.Application.Services
{
    public interface IDbContext
    {
        public DatabaseFacade Database { get; }
        public DbSet<Entry> Entries { get; set; }
        public DbSet<Photo> Photos { get; set; }
        public DbSet<Camera> Cameras { get; set; }
        public DbSet<Film> Films { get; set; }
        public EntityEntry Entry([NotNullAttribute] object entity);
        public EntityEntry<TEntity> Entry<TEntity>([NotNullAttribute] TEntity entity) where TEntity : class;
        public Task<int> SaveChangesAsync(CancellationToken cancellationToken);

    }
}