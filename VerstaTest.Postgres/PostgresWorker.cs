using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VerstaTest.Data;
using VerstaTest.Data.Data;
using VerstaTest.Postgres.Abstract;

namespace VerstaTest.Postgres
{
    public class PostgresWorker<T> : IPostgresWorker<T> where T : class
    {

        public int ItemsInDb
        {
            get
            {
                return _dataContext.Orders.Count();
            }
        }

        private DataContext _dataContext { get; set; }

        public PostgresWorker(DataContext dataContext)
        {
            _dataContext = dataContext ?? throw new ArgumentNullException(nameof(dataContext));
        }

        public async void AddAsync(T item)
        {
            await _dataContext.AddAsync(item);
            _dataContext.SaveChanges();
        }

        public async void Update(T updatedItem)
        {
            _dataContext.Update(updatedItem);
            await _dataContext.SaveChangesAsync();
        }

        public async void RemoveAsync(Guid itemId)
        {
            var objectFromDb = await _dataContext.FindAsync(typeof(T), itemId);

            if(objectFromDb == null)
            {
                throw new Exception("Object does not exist");
            }

            _dataContext.Remove(objectFromDb);
            await _dataContext.SaveChangesAsync();
        }

        public async Task<T> GetByIdAsync(int itemId) => (T)await _dataContext.FindAsync(typeof(T), itemId);

        public async Task<T> GetByGuidAsync(Guid itemId) => (T)await _dataContext.FindAsync(typeof(T), itemId);

        public IEnumerable<Order> GetAllOrders()
        {
            var allRows = _dataContext.Orders.ToArray();
            foreach (var item in allRows)
            {
                yield return item;
            }
        }
    }
}
