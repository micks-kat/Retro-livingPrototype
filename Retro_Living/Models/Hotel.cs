using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Retro_Living.Models
{
    public class Hotel
    {
        [Key]
        public int h_id { get; set; }
        public string h_name { get; set; }
        public string h_contacts { get; set; }
        public string h_email_address { get; set; }
        public string h_description { get; set; }
        public string h_address { get; set; }
        public ICollection<User_Hotel> user_hotels { get; set; }
        public ICollection<Hotel_Room> hotel_room { get; set; }
    }
}
