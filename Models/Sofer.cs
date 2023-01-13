using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace ProiectBun.Models
{
    public class Sofer
    {
        public int ID { get; set; }

        [Display(Name = "Numele Soferului")]
        public string SoferName { get; set; }

        
        public ICollection<Utilaj>? Utilaje { get; set; }
    }
}
