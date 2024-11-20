using Microsoft.AspNetCore.Mvc;
using Week8_EmptyMvc.Models;

namespace Week8_EmptyMvc.Controllers
{
    public class CustomerOrderController : Controller
    {
        public IActionResult Index()
        {
            var customer = new Customer
            {
                Id = 1,
                FirstName = "Ezgi",
                LastName = "Gecimli",
                Email = "ezgi@gmail.com"
            };

            var orders = new List<Order>
            {
                new Order
                {
                    OrderId = 1,
                    ProductName = "Dyson",
                    Price = 400,
                    Quantity = 1
                },
                new Order
                {
                    OrderId = 2,
                    ProductName = "MacBook",
                    Price = 1200,
                    Quantity = 1
                }
            };


            var customerViewModel = new CustomerViewModel
            {
                Customer = customer,
                Orders = orders

            };

            return View(customerViewModel);
        }
    }
}
