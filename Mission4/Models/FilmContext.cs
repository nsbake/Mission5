using System;
using Microsoft.EntityFrameworkCore;

namespace Mission4.Models
{
    public class FilmContext : DbContext
    {
        public FilmContext(DbContextOptions<FilmContext> options) : base(options)
        {

        }

        public DbSet<Film> Responses { get; set; }

        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<Film>().HasData(
                new Film
                {
                    FilmID = 1,
                    Category = "Action",
                    Title = "Ford vs Ferarri",
                    Year = 2019,
                    Director = "James Mangold",
                    Rating = "PG-13"
                },
                new Film
                {
                    FilmID = 2,
                    Category = "History",
                    Title = "Miracle",
                    Year = 2004,
                    Director = "Gavin O'Connor",
                    Rating = "PG"
                },
                new Film
                {
                    FilmID = 3,
                    Category = "Action",
                    Title = "The Dark Knight",
                    Year = 2008,
                    Director = "Christopher Nolan",
                    Rating = "PG-13"
                }
            );
        }
    }
}
