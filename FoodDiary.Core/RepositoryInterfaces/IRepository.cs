using FoodDiary.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace FoodDiary.Core.RepositoryInterfaces
{
    public interface IRepository<TEntity, in TKey> where TEntity : Entity<TKey>
    {
        TEntity Find(TKey id);
        IEnumerable<TEntity> List(Expression<Func<TEntity, bool>> predicate = null);
    }
}
