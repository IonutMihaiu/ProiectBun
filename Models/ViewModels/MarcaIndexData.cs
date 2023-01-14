using ProiectBun.Models;
using System.Security.Policy;

namespace ProiectBun.Models.ViewModels

{
    public class MarcaIndexData
    {
        public IEnumerable<Marca> Marci { get; set; }
        public IEnumerable<Utilaj> Utilaje { get; set; }
    }
}
