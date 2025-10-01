using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LBMS_V1.Models
{
    public class borrow
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BorrowID { get; set; }

        // Foreign Key References
        public int BookID { get; set; }
        public Books Book { get; set; }

        public int MemberID { get; set; }
        public Member Member { get; set; }

        public DateTime BorrowDate { get; set; }
        public DateTime? ReturnDate { get; set; }
    }
}
