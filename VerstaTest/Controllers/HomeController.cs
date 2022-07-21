using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using VerstaTest.Core.Abstract;
using VerstaTest.ViewModels;

namespace VerstaTest.Controllers
{
    public class HomeController : Controller
    {
        private readonly IOrderService _orderService;
        public HomeController(IOrderService orderService)
        {
            _orderService = orderService ?? throw new ArgumentNullException(nameof(orderService));

        }

        public IActionResult Index()
        {
            var viewModel = new HomeViewModel
            {
                Orders = _orderService.GetAllOrders()
            };
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> CreateNewOrder(string adressersCity,
                                          string adressersAdress,
                                          string recipientsCity,
                                          string recipientsAdress,
                                          double cargoWeight,
                                          DateTime collectionDate)
        {
            if (!string.IsNullOrEmpty( adressersCity) &&
                !string.IsNullOrEmpty( adressersAdress) &&
                !string.IsNullOrEmpty( recipientsCity) &&
                !string.IsNullOrEmpty( recipientsAdress) &&
                cargoWeight != 0 &&
                collectionDate != null)
            await _orderService.CreateOrderAsync(adressersCity, adressersAdress, recipientsCity, recipientsAdress, cargoWeight, collectionDate);
            return RedirectToAction("Index", "Home");
        }


    }
}
