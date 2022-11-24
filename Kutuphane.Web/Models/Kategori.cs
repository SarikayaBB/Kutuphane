using System.ComponentModel.DataAnnotations.Schema;

namespace Kutuphane.Web.Models
{
    [Table("Kategoriler")]
    public class Kategori : ModelBase
    {
        public string Ad { get; set; }
        public string ISBN { get; set; }
    }
}
