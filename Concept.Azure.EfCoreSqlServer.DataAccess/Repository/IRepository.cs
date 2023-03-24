using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Concept.Azure.EfCoreSqlServer.DataAccess.Repository
{
    public interface IRepository<T> : IDisposable
    {
        Task<IEnumerable<T>> GetItems();
        Task<T> GetItemsById(object id);
        T InsertItem(T item);
        Task DeleteItem(object id);
        Task UpdateItem(T item);
        Task Save();
    }
}
