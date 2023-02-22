using CleanMovie.Domain;
using Microsoft.EntityFrameworkCore;

namespace CleanMovie.Infrastructure
{
    public interface IMovieDbContext
    {
        public DbSet<Movie>? Movies { get; set; }
        public DbSet<Rental>? Rentals { get; set; }
        public DbSet<Member>? Members { get; set; }
        public DbSet<MovieRental>? MovieRentals { get; set; }
    }
}
