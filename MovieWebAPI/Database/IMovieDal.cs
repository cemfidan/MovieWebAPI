using MovieWebAPI.Entities;

namespace MovieWebAPI.Database
{
    public interface IMovieDal
    {
        void Add(Movie movie);
        void Delete(int id);
        void Update(Movie movie);
        List<Movie> GetAll();
        Movie GetById(int id);
    }
}
