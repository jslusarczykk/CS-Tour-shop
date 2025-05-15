using C_SHOP.Models;
using Microsoft.AspNetCore.Mvc;

namespace C_SHOP.Controllers
{
    public class AdminController : Controller
    {
        private myContext _context;
        private IWebHostEnvironment _env;
        public AdminController(myContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        public IActionResult Index()
        {
            string admin_session = HttpContext.Session.GetString("admin_session");
            if (admin_session != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("login");
            }    
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(string adminEmail, string adminPassword)
        {
            var row = _context.tbl_admin.FirstOrDefault(a => a.admin_email == adminEmail);
            if (row != null && row.admin_password == adminPassword)
            {
                HttpContext.Session.SetString("admin_session", row.admin_id.ToString());
                return RedirectToAction("index");
            }
            else
            {
                ViewBag.message = "Incorrect Username or Password";
                return View();
            }

        }
        public IActionResult Logout()
        {
            HttpContext.Session.Remove("admin_session");
            return RedirectToAction("login");
        }

        public IActionResult Profile()
        {
            var adminId = HttpContext.Session.GetString("admin_session");
            var row = _context.tbl_admin.Where(a => a.admin_id == int.Parse(adminId)).ToList();
            return View(row);
        }
        [HttpPost]
        public IActionResult Profile(Admin admin)
        {
            _context.tbl_admin.Update(admin);
            _context.SaveChanges();
            return RedirectToAction("Profile");
        }
        [HttpPost]
        public IActionResult ChangeProfileImage(IFormFile admin_image,Admin admin)
        {
            string ImagePath = Path.Combine(_env.WebRootPath, "admin_image", admin_image.FileName);
            FileStream fs = new FileStream(ImagePath, FileMode.Create);
            admin_image.CopyTo(fs);
            admin.admin_image=admin_image.FileName;
            _context.tbl_admin.Update(admin);
            _context.SaveChanges();
            return RedirectToAction("Profile");
        }
        public IActionResult fetchCustomer() {
            return View(_context.tbl_customer.ToList());
        }
        public IActionResult customerDetails(int id)
        {
            return View(_context.tbl_customer.FirstOrDefault(c => c.customer_id == id));
        }
        public IActionResult updateCustomer(int id)
        {
            return View(_context.tbl_customer.Find(id));
        }
        [HttpPost]
        public IActionResult updateCustomer(Customer customer, IFormFile customer_image)
        {
            // 1) If they picked a new file, save it and update the property
            if (customer_image != null && customer_image.Length > 0)
            {
                var fileName = Path.GetFileName(customer_image.FileName);
                var savePath = Path.Combine(_env.WebRootPath, "customer_images", fileName);
                using var fs = new FileStream(savePath, FileMode.Create);
                customer_image.CopyTo(fs);
                customer.customer_image = fileName;
            }
            // 2) otherwise leave customer.customer_image as it was (you must preserve it!)
            //    e.g. by including a hidden field in your form:
            //    <input type="hidden" name="customer_image" value="@Model.customer_image" />

            _context.tbl_customer.Update(customer);
            _context.SaveChanges();
            return RedirectToAction("fetchCustomer");
        }
        public IActionResult deletePermission(int id)
        {
            return View(_context.tbl_customer.FirstOrDefault(c => c.customer_id == id));
        }
        public IActionResult deleteCustomer(int id)
        {
            var customer = _context.tbl_customer.Find(id);
            _context.tbl_customer.Remove(customer);
            _context.SaveChanges();
            return RedirectToAction("fetchCustomer");
        }
        public IActionResult fetchCategory()
        {
            return View(_context.tbl_category.ToList());
        }
        public IActionResult addCategory()
        {
            return View();
        }
        [HttpPost]
        public IActionResult addCategory(Category cat)
        {
            _context.tbl_category.Add(cat);
            _context.SaveChanges();
            return RedirectToAction("fetchCategory");
        }
        public IActionResult updateCategory(int id)
        {
            var category = _context.tbl_category.Find(id);
            return View(category);
        }
        [HttpPost]
        public IActionResult updateCategory(Category cat)
        {
            _context.tbl_category.Update(cat);
            _context.SaveChanges();
            return RedirectToAction("FetchCategory") ;
        }
        public IActionResult deletePermissionCategory(int id)
        {
            return View(_context.tbl_category.FirstOrDefault(c => c.category_id == id));
        }
        public IActionResult deleteCategory(int id)
        {
            var category = _context.tbl_category.Find(id);
            _context.tbl_category.Remove(category);
            _context.SaveChanges();
            return RedirectToAction("fetchCategory");
        }
        public IActionResult fetchProduct()
        {
            return View(_context.tbl_product.ToList());
        }
        public IActionResult addProduct()
        {
            List<Category> categories = _context.tbl_category.ToList();
            ViewData["category"] = categories;
            return View();
        }
        [HttpPost]
        public IActionResult addProduct(Product prod,IFormFile product_image)
        {
            string imageName = Path.GetFileName(product_image.FileName);
            string imagePath = Path.Combine(_env.WebRootPath, "product_images", imageName);
            FileStream fs = new FileStream(imagePath, FileMode.Create);
            product_image.CopyTo(fs);
            prod.product_image = imageName;
            _context.tbl_product.Add(prod);
            _context.SaveChanges();
            return RedirectToAction("fetchProduct");
        }

    }
}
