using MCC73MVC.Contexts;
using MCC73MVC.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace MCC73MVC.Repositories
{
    public class GeneralRepository<Context, Entity, Key> : IRepository<Entity, Key>
    where Entity : class
    where Context : MyContext
    {
        private MyContext _context;
        private DbSet<Entity> _entity;
        public GeneralRepository(Context context)
        {
            _context = context;
            _entity = context.Set<Entity>();
        }

        public int Delete(Key key)
        {
            var data = _entity.Find(key);
            if (data == null)
            {
                return 0;
            }

            _entity.Remove(data);
            var result = _context.SaveChanges();
            return result;
        }

        public IEnumerable<Entity> Get()
        {
            return _entity.ToList();
        }

        public Entity Get(Key key)
        {
            return _entity.Find(key);
        }

        public int Insert(Entity entity)
        {
            _entity.Add(entity);
            var result = _context.SaveChanges();
            return result;
        }

        public int Update(Entity entity)
        {
            _entity.Entry(entity).State = EntityState.Modified;
            var result = _context.SaveChanges();
            return result;
        }
    }
}
