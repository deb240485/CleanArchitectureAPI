using CleanMovie.Application;
using CleanMovie.Domain;

namespace CleanMovie.Infrastructure
{
    public class MovieRepository : IMovieRepository
    {
        
        //public static List<Movie> movies = new List<Movie>()
        //{
        //    new Movie{ Id = 1, Name = "Passion of Christ", Cost = 2},
        //    new Movie { Id =2, Name = "Home Alone 4" , Cost = 3}
        //};

        private readonly MovieDBContext _dBContext;

        public MovieRepository(MovieDBContext dBContext)
        {
            _dBContext = dBContext;
        }

        public Movie CreateMovie(Movie movie)
        {
            _dBContext.Movies!.Add(movie);
            _dBContext.SaveChanges();
            return movie;
        }

        public List<Movie> GetAllMovies()
        {
           return _dBContext.Movies!.ToList();
        }
    }
}
