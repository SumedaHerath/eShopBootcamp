using eShop.Core.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace eShop.Core
{
    public interface IDocumentStore<T> where T : Entity, new()
    {
        string Collection { get; set; }
        Task<T> GetItemByIdAsync(string id);
        Task<T> CreateItemAsync(T entity);
        Task<T> UpdateItemAsync(string id, T entity);
        List<T> GetItems(Expression<Func<T, bool>> predicate, bool AllowCrossPartition = false);
    }
}
