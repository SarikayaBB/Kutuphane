using Kutuphane.Web.Data;
using Microsoft.AspNetCore.Mvc;
using Kutuphane.Web.Models;
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
            return Json(_db.Kategoriler.OrderByDescending(ord => ord.DateCreated).ToList());
        }

        [HttpPost]
        public IActionResult FindById(Guid kategoriId)
        {
            Kategori kategori = _db.Kategoriler.FirstOrDefault(k=> k.Id == kategoriId);
            return Json(kategori);
        }

        [HttpPost]
        public IActionResult Add(string isbn, string ad)
        {
            Kategori addedKategori = new Kategori();
            addedKategori.Ad = ad;
            addedKategori.ISBN = isbn;
            addedKategori.IsDeleted = false;
            addedKategori.IsActive = true;
            addedKategori.Id = Guid.NewGuid();
            addedKategori.DateCreated = DateTime.Now;
            addedKategori.DateModified = DateTime.Now;
            _db.Kategoriler.Add(addedKategori);
            _db.SaveChanges();
            return Ok();
        }

        public IActionResult Delete(Guid kategoriId) 
        {
            Kategori deletedKategori = _db.Kategoriler.FirstOrDefault(k=>k.Id == kategoriId);
            _db.Remove(deletedKategori);
            _db.SaveChanges();
            return Json(kategoriId);
        }

        public IActionResult Edit(string ad,string isbn,Guid kategoriId) 
        {
            Kategori editedKategori = _db.Kategoriler.FirstOrDefault(k=>k.Id == kategoriId);
            editedKategori.Ad = ad;
            editedKategori.ISBN = isbn;
            _db.Update(editedKategori);
            _db.SaveChanges();
            return Ok();

        }

    }
}
