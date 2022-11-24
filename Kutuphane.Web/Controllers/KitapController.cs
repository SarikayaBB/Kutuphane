using Kutuphane.Web.Data;
using Kutuphane.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace Kutuphane.Web.Controllers
{
    public class KitapController : Controller
    {
        private readonly ApplicationDbContext _db;

        public KitapController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetAll()
        {
            return Json(_db.Kitaplar);
        }

        [HttpPost]
        public IActionResult FindById(Guid kitapId)
        {
            Kitap kitap = _db.Kitaplar.Find(kitapId);
            return Json(kitap);
        }
    }
}
