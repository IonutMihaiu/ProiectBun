using System.ComponentModel.DataAnnotations;

namespace ProiectBun.Models
{
    public class Borrowing
    {
        public int ID { get; set; }
        public int? MemberID { get; set; }
        public Member? Member { get; set; }
        public int? UtilajID { get; set; }
        public Utilaj? Utilaj { get; set; }
        [DataType(DataType.Date)]
        public DateTime ReturnDate { get; set; }
    }
}
