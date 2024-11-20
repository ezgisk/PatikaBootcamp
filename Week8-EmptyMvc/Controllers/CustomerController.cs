using Microsoft.AspNetCore.Mvc;
using Week8_EmptyMvc.Models;

namespace Week8_EmptyMvc.Controllers
{
    public class CustomerController : Controller
    {
        public IActionResult Index()
        {
            var customer = new Customer
            {
                Id = 1,
                FirstName = "John",
                LastName = "Doe",
                Email = "john.doe@example.com"
            };

            // ViewModel oluşturup view'a gönderiyoruz
            var viewModel = new CustomerViewModel
            {
                Customer = customer,
                WelcomeMessage = "Welcome to our customer portal!"
            };

            return View(viewModel);
        }
    }
}
