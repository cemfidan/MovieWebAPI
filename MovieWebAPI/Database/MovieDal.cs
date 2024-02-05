using Microsoft.EntityFrameworkCore;
using MovieWebAPI.Entities;

namespace MovieWebAPI.Database
{
    public class MovieDal : IMovieDal
    {
        public void Add(Movie movie)
        {
            using (var context = new DatabaseContext())
            {
                var result = context.Entry(movie);
                result.State = EntityState.Added;
                context.SaveChanges();
            }
        }
        public void Delete(int id)
        {
            using (var context = new DatabaseContext())
            {
                var movie = context.Movies.Find(id);
                context.Movies.Remove(movie);
                context.SaveChanges();
            }
        }
        public void Update(Movie movie)
        {
            using (var context = new DatabaseContext())
            {
                var result = context.Entry(movie);
                result.State = EntityState.Modified;
                context.SaveChanges();
            }
        }
        public List<Movie> GetAll()
        {
            using var value = new DatabaseContext();
            return value.Set<Movie>().ToList();
        }
        public Movie GetById(int id)
        {
            using (var context = new DatabaseContext())
            {
                return context.Movies.Find(id);
            }
        }
    }
}
