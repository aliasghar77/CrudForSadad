using CrudFroSadad.Data;
using CrudFroSadad.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CrudFroSadad.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private CrudContext _context;


        public HomeController(CrudContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var product = _context.Users.ToList();
            return View(product);
        }

        public IActionResult Delete(int UserId)
        {
            var _user = _context.Users.FirstOrDefault(i=>i.UserId == UserId);

            _context.Users.Remove(_user);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int UserId)
        {
            var _user = _context.Users.FirstOrDefault(i => i.UserId == UserId);

            return View(_user);
        }

        [HttpPost]
        public IActionResult Edit(User user)
        {
            var userEdite = _context.Users.First(p => p.UserId == user.UserId);

            userEdite.Email = user.Email;
            userEdite.Password = user.Password;

            _context.SaveChanges();

            return RedirectToAction("Index");
        }


        public IActionResult Register(User Users)
        {
            if(ModelState.IsValid)
            {
                var newUser = new User()
                {
                    Email = Users.Email,
                    Password = Users.Password,
                    RegisterDate = DateTime.Now
                    
                };
                _context.Add(newUser);
                _context.SaveChanges();

                return RedirectToAction("Index");
            }

            return View();
            
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
