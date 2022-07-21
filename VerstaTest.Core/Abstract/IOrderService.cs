using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using VerstaTest.Data.Data;

namespace VerstaTest.Core.Abstract
{
    public interface IOrderService
    {
        public Task CreateOrderAsync(string adressersCity,
                                string adressersAdress, 
                                string recipientsCity, 
                                string recipientsAdress, 
                                double cargoWeight, 
                                DateTime collectionDate);
        public IEnumerable<Order> GetAllOrders();
    }
}
