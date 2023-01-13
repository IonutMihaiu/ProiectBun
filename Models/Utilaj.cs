using System.ComponentModel.DataAnnotations;
using System.Security.Policy;
using System.Xml.Linq;

namespace ProiectBun.Models
{
    public class Utilaj
    {
        public int ID { get; set; }

        [Display(Name = "Numele Utilajului")]
        public string NumeUtilaj { get; set; }
        public int? SoferID { get; set; }
        public Sofer? Sofer { get; set; }

        [Display(Name = "Pret pe zi in lei")]
        public decimal Pret { get; set; }

        
        [Display(Name = "Data inceperii")]
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }

       
        [Display(Name = "Data sfarsirii")]
        [DataType(DataType.Date)]
        public DateTime FinishDate { get; set; }

        public int? MarcaID { get; set; }
        public Marca? Marca{ get; set; }
    }
}
