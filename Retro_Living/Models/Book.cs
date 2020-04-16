using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Retro_Living.Models
{
    public class Book
    {

        [Key]
        public int b_id { get; set; }
        public DateTime booking_time { get; set; }
        public DateTime check_in_time { get; set; }
        public DateTime check_out_time { get; set; }
        public ICollection<Room> room { get; set; }
        public ICollection<Invoice> book_invoice { get; set; }
        public ICollection<User_Book> user_book { get; set; }

    }
}
