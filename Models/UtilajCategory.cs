namespace ProiectBun.Models
{
    public class UtilajCategory
    {
        public int ID { get; set; }
        public int UtilajID { get; set; }
        public Utilaj Utilaj{ get; set; }
        public int CategoryID { get; set; }
        public Category Category { get; set; }
    }
}
