using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Retro_Living.Models
{
    public class User
    {

        [Key]
        public int user_id { get; set; }
        public string user_first_name { get; set; }
        public string user_last_name { get; set; }
        public string user_gender { get; set; }
        public string user_dob { get; set; }
        public string user_nationality { get; set; }
        public string user_email_address { get; set; }
        public string user_contacts { get; set; }
        public string user_password { get; set; }
        public string user_address { get; set; }
        public int user_type { get; set; }
        public ICollection<User_Hotel> user_hotels { get; set; }
        public ICollection<User_Book> user_book { get; set; }
        public virtual ICollection<Invoice> user_invoice { get; set; }



    }
}
