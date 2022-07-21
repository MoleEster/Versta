using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using VerstaTest.Core.Abstract;
using VerstaTest.Data.Data;
using VerstaTest.Postgres.Abstract;

namespace VerstaTest.Core.Services
{
    public class OrderService : IOrderService
    {
        private readonly IPostgresWorker<Order> _postgresWorker;
        public OrderService(IPostgresWorker<Order> postgresWorker)
        {
            _postgresWorker = postgresWorker ?? throw new ArgumentNullException(nameof(postgresWorker));
        }

        public async Task CreateOrderAsync(string adressersCity,
                                                 string adressersAdress,
                                                 string recipientsCity,
                                                 string recipientsAdress,
                                                 double cargoWeight,
                                                 DateTime collectionDate)
        {
            var orderGuid = Guid.NewGuid();
            var newOrder = new Order
            {
                AdressersAdress = adressersAdress ,
                AdressersCity = adressersCity,
                CargoWeight = cargoWeight,
                CollectionDate = collectionDate,
                Id = orderGuid,
                RecipientsAdress = recipientsAdress,
                RecipientsCity = recipientsCity
            };

            _postgresWorker.AddAsync(newOrder);
        }

        public IEnumerable<Order> GetAllOrders() => _postgresWorker.GetAllOrders();
    }
}
