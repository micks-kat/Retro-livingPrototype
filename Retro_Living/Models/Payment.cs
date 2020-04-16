using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Retro_Living.Models
{
    public class Payment
    {

        [Key]
        public int p_id { get; set; }
        public double paid_amount { get; set; }
        public DateTime time_paid { get; set; }
        public ICollection<User_Book> user_book { get; set; }
        public ICollection<Invoice> user_invoice { get; set; }
        public ICollection<Invoice> pay_invoice { get; set; }

    }
}
