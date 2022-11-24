using System.ComponentModel.DataAnnotations.Schema;

namespace Kutuphane.Web.Models
{
    [Table("Kitaplar")]
    public class Kitap : ModelBase
    {
        public string Ad { get; set; }
        public Guid KategoriId { get; set; }
        public virtual Kategori Kategori { get; set; }
        public string Ozet { get; set; }

    }
}
