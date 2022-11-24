using Kutuphane.Web.Data;
using Kutuphane.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Kutuphane.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _db;
        public HomeController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}