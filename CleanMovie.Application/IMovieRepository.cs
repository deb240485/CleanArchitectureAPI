using CleanMovie.Domain;

namespace CleanMovie.Application
{
    public interface IMovieRepository
    {
        List<Movie> GetAllMovies();
        Movie CreateMovie(Movie movie);
    }
}
