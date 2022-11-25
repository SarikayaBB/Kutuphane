using Kutuphane.Web.Data;
using Microsoft.AspNetCore.Mvc;

namespace Kutuphane.Web.Controllers
{
    public class KategoriController : Controller
    {
        private readonly ApplicationDbContext _db;
        public KategoriController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetAll()
        {
            return Json(_db.Kategoriler.ToList());
        }
    }
}
