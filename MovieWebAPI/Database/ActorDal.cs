using Microsoft.EntityFrameworkCore;

namespace MovieWebAPI.Database
{
    public class ActorDal
    {
        public void Add(Actor actor)
        {
            using (var context = new DatabaseContext())
            {
                var result = context.Entry(actor);
                result.State = EntityState.Added;
                context.SaveChanges();
            }
        }
        public void Delete(int id)
        {
            using (var context = new DatabaseContext())
            {
                var actor = context.Actors.Find(id);
                context.Actors.Remove(actor);
                context.SaveChanges();
            }
        }
        public void Update(Actor actor)
        {
            using (var context = new DatabaseContext())
            {
                var result = context.Entry(actor);
                result.State = EntityState.Modified;
                context.SaveChanges();
            }
        }
        public List<Actor> GetAll()
        {
            using var value = new DatabaseContext();
            return value.Set<Actor>().ToList();
        }
        public Actor GetById(int id)
        {
            using (var context = new DatabaseContext())
            {
                return context.Actors.Find(id);
            }
        }
    }
}
