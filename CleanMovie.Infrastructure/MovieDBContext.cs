using CleanMovie.Domain;
using Microsoft.EntityFrameworkCore;

namespace CleanMovie.Infrastructure
{
    public class MovieDBContext : DbContext ,IMovieDbContext
    {
        public MovieDBContext(DbContextOptions<MovieDBContext> options): base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //One to Many (Member & Rentals)
            modelBuilder.Entity<Member>()
                .HasOne<Rental>(s => s.Rental)
                .WithMany(r => r.Members)
                .HasForeignKey(r => r.RentalId);

            //Many to Many (Rental and Movie)
            modelBuilder.Entity<MovieRental>()
                .HasKey(g => new { g.RentalId, g.MovieId });

            //Handle Decimals to avoid Precision loss
            modelBuilder.Entity<Rental>()
                .Property(p => p.TotalCost)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<Movie>()
                .Property(p => p.RentalCost)
                .HasColumnType("decimal(18,2)");
        }

        public DbSet<Movie>? Movies { get; set; }
        public DbSet<Rental>? Rentals { get; set; }
        public DbSet<Member>? Members { get; set; }
        public DbSet<MovieRental>? MovieRentals { get; set; }
    }
}
