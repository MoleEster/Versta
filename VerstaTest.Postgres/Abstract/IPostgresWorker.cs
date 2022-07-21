using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using VerstaTest.Data.Data;

namespace VerstaTest.Postgres.Abstract
{
    public interface IPostgresWorker<T> where T: class
    {
        public int ItemsInDb { get; }
        public void AddAsync(T item);

        public void Update(T updatedItem);

        public Task<T> GetByIdAsync(int itemId);
        public Task<T> GetByGuidAsync(Guid itemId);
        public IEnumerable<Order> GetAllOrders();

        public void RemoveAsync(Guid itemId);
    }
}
