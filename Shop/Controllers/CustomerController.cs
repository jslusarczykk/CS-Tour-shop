using C_SHOP.Models;
using Microsoft.AspNetCore.Mvc;

namespace C_SHOP.Controllers
{
    public class CustomerController : Controller
    {
        private myContext _context;

        public CustomerController(myContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            List<Category> category = _context.tbl_category.ToList();
            ViewData["category"] = category;
            return View();
        }
        public IActionResult customerLogin()
        {
            return View();
        }
        [HttpPost]
        public IActionResult customerLogin(String customerEmail,String customerPassword)
        {
            var customer = _context.tbl_customer.FirstOrDefault(c => c.customer_email == customerEmail);
            if(customer != null && customer.customer_password == customerPassword)
            {
                HttpContext.Session.SetString("customerSession", customer.customer_id.ToString());
                return RedirectToAction("Index");
            }
            else
            {
                // Login failed, show error message
                ViewBag.ErrorMessage = "Invalid email or password.";
                return View();
            }
        }
        public IActionResult CustomerRegistration()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CustomerRegistration(Customer customer)
        {
            _context.tbl_customer.Add(customer);
            _context.SaveChanges();
            return RedirectToAction("customerLogin");
        }
    }
}
