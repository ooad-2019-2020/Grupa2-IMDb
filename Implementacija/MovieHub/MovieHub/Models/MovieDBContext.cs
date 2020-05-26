using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieHub.Models
{
    public class MovieDBContext : DbContext
    {
        public MovieDBContext(DbContextOptions<MovieDBContext> options) : base(options)
        {
        }
        public DbSet<Film> Film { get; set; }
        public DbSet<Zanr> Zanr { get; set; }
        public DbSet<FilmZanr> FilmZanr { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Film>().ToTable("Film");
            modelBuilder.Entity<Zanr>().ToTable("Zanr");
            modelBuilder.Entity<FilmZanr>().ToTable("FilmZanr");
        }
    }
}
