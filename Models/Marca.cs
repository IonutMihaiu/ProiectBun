using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace ProiectBun.Models
{
    public class Marca
    {
        public int ID { get; set; }

        [Display(Name = "Marca Utilajului")]
        public string MarcaName { get; set; }
        public ICollection<Utilaj>? Utilaje { get; set; }
    }
}
