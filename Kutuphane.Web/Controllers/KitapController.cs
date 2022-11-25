using Kutuphane.Web.Data;
using Kutuphane.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
            return Json(_db.Kitaplar.Include(k => k.Kategori).ToList());
        }

        [HttpPost]
        public IActionResult FindById(Guid kitapId)
        {
            //var test = _db.Kitaplar.Join(_db.Kategoriler, kitap => kitap.KategoriId, kategori => kategori.Id, (kitap, kategori) => new
            //{
            //    kitap.Ozet,
            //    kitap.Ad,
            //    kitap.Id,
            //    kitap.KategoriId,
            //    kitap.DateCreated,
            //    kitap.DateModified,
            //    kitap.IsDeleted,
            //    kitap.IsActive,
            //    kad = kategori.Ad.ToString(),
            //})
            //    .Select(s => s).Where(t => t.Id == kitapId).ToList();
            Kitap kitap = _db.Kitaplar.Include(k => k.Kategori).FirstOrDefault(f => f.Id == kitapId);
            return Json(kitap);
        }
        [HttpPost]
        public IActionResult Edit(string ozet, string kitapAdi, Guid kitapId, string kategori)
        {
            //Kitap editedKitap = _db.Kitaplar.Include(k => k.Kategori).FirstOrDefault(f => f.Id == kitapId);
            Kitap editedKitap = _db.Kitaplar.Find(kitapId);
            var kategoriId = _db.Kategoriler.Select(k => new { k.Id, k.Ad }).Where(w => w.Ad == kategori.ToString()).FirstOrDefault();
            editedKitap.Ozet = ozet.ToString();
            editedKitap.Ad = kitapAdi.ToString();
            editedKitap.KategoriId = kategoriId.Id;
            _db.SaveChanges();
            return Json(_db.Kitaplar.Include(k=>k.Kategori).Where(w=>w.Id==kitapId).FirstOrDefault());
        }
    }
}
