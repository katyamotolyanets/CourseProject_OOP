using Microsoft.EntityFrameworkCore;
using FoodDiary.Core.Models;

namespace FoodDiary.Infrastructure.Repositories
{
    public class Repository<TEntity> where TEntity : Entity
    {
        protected readonly FoodDiaryContext Context;
        protected readonly DbSet<TEntity> DbSet;

        protected Repository()
        {
            Context = new FoodDiaryContext();
            DbSet = Context.Set<TEntity>();
        }
    }
}
