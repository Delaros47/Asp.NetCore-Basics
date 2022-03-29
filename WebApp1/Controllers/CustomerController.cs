using Microsoft.AspNetCore.Mvc;
using WebApp1.Models;

namespace WebApp1.Controllers
{
    public class CustomerController : Controller
    {
        public IActionResult Index()
        {
            var customers = CustomerContext.Customers;
            return View(customers);
        }
        
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Customer customer)
        {
            int id = 0;
            if (CustomerContext.Customers.Count>0)
            {
                id = CustomerContext.Customers.Last().Id++;

            }
            else
            {
                id++;
            }
            CustomerContext.Customers.Add(new Customer
            {
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                Age = customer.Age,
                Id = id,
            });
            return RedirectToAction("Index", "Customer");
        }

        public IActionResult Delete(int id)
        {
            var deleted = CustomerContext.Customers.SingleOrDefault(c=>c.Id==id);
            CustomerContext.Customers.Remove(deleted);
            return RedirectToAction("Index", "Customer");
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            var updated = CustomerContext.Customers.SingleOrDefault(c=>c.Id==id);
            return View(updated);
        }

        [HttpPost]
        public IActionResult Update(Customer customer)
        {
            var updated = CustomerContext.Customers.SingleOrDefault(c=>c.Id==customer.Id);
            updated.FirstName = customer.FirstName;
            updated.LastName = customer.LastName;
            updated.Age = customer.Age;

            return RedirectToAction("Index", "Customer");
        }
    }
}
