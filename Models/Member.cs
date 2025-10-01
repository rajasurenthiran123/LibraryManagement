using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LBMS_V1.Models
{
    public class Member
    {

        // Member primary key we re using Guid for security purpose - Raja
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid MemberID { get; set; } = Guid.NewGuid();

        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime JoinDate { get; set; }

        public ICollection<borrow>? Borrows { get; set; }
    }
}
