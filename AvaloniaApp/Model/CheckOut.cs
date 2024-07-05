using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvaloniaApp.Model
{
    public class CheckOut
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [ForeignKey("Book")]
        public int BookId { get; set; }
        public virtual Book Book { get; set; }

        [ForeignKey("Borrower")]
        public int BorrowerId { get; set; }
        public virtual User Borrower { get; set; }
        public DateTime BorrowTime { get; set; }
    }
}
