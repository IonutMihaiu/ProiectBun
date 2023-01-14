namespace ProiectBun.Models
{
    public class UtilajData
    {
        public IEnumerable<Utilaj> Utilaje { get; set; }
        public IEnumerable<Category> Categories { get; set; }
        public IEnumerable<UtilajCategory> UtilajCategories { get; set; }
    }
}
