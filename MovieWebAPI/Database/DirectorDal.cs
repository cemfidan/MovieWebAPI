using Microsoft.EntityFrameworkCore;

namespace MovieWebAPI.Database
{
    public class DirectorDal
    {
        public void Add(Director director)
        {
            using (var context = new DatabaseContext())
            {
                var result = context.Entry(director);
                result.State = EntityState.Added;
                context.SaveChanges();
            }
        }
        public void Delete(int id)
        {
            using (var context = new DatabaseContext())
            {
                var director = context.Directors.Find(id);
                context.Directors.Remove(director);
                context.SaveChanges();
            }
        }
        public void Update(Director director)
        {
            using (var context = new DatabaseContext())
            {
                var result = context.Entry(director);
                result.State = EntityState.Modified;
                context.SaveChanges();
            }
        }
        public List<Director> GetAll()
        {
            using var value = new DatabaseContext();
            return value.Set<Director>().ToList();
        }
        public Director GetById(int id)
        {
            using (var context = new DatabaseContext())
            {
                return context.Directors.Find(id);
            }
        }
    }
}
