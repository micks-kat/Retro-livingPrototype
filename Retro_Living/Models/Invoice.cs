using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Retro_Living.Models
{
    public class Invoice
    {
        [Key]
        public int inv_id { get; set; } 
        public DateTime invoice_time { get; set; }
        
        public User user { get; internal set; }
        public Payment pay { get; set; }
        public Book book { get; set; }
    }
}
