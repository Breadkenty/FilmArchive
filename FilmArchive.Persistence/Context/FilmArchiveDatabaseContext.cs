using System;
using System.Text.RegularExpressions;
using FilmArchive.Application.Services;
using FilmArchive.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace FilmArchive.Persistence.Context
{
    public partial class FilmArchiveDatabaseContext : DbContext, IDbContext
    {
        private static string DEVELOPMENT_DATABASE_NAME = "FilmArchiveDatabase";

        private static bool LOG_SQL_STATEMENTS_IN_DEVELOPMENT = false;

        public FilmArchiveDatabaseContext(DbContextOptions<FilmArchiveDatabaseContext> options) : base(options)
        {
        }
        public DbSet<Entry> Entries { get; set; }
        public DbSet<Camera> Cameras { get; set; }
        public DbSet<Film> Films { get; set; }
        public DbSet<Photo> Photos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (LOG_SQL_STATEMENTS_IN_DEVELOPMENT && Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Development")
            {
                var loggerFactory = LoggerFactory.Create(builder => builder.AddConsole());
                optionsBuilder.UseLoggerFactory(loggerFactory);
            }

            if (!optionsBuilder.IsConfigured)
            {
                var databaseURL = Environment.GetEnvironmentVariable("DATABASE_URL");
                var defaultConnectionString = $"server=localhost;database={DEVELOPMENT_DATABASE_NAME}";

                var conn = databaseURL != null ? databaseURL : defaultConnectionString;

                optionsBuilder.UseNpgsql(conn);
            }
        }
    }
}