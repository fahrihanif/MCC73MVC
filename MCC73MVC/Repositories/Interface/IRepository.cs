using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace MCC73MVC.Repositories.Interface
{
    public interface IRepository<Entity, Key>
    {
        IEnumerable<Entity> Get();
        Entity Get(Key key);
        int Insert(Entity entity);
        int Update(Entity entity);
        int Delete(Key key);
    }
}
