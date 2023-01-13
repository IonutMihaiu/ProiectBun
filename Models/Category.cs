namespace ProiectBun.Models
{
    public class Category
    {
        public int ID { get; set; }
        public string CategoryName { get; set; }
        public ICollection<UtilajCategory>? UtilajCategories { get; set; }
    }
}
