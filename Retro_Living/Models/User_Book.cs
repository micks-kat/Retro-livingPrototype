using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Retro_Living.Models
{
    public class User_Book
    {
        public int user_id { get; set; }
        public virtual User user { get; set; }
        public int b_id { get; set; }
        public virtual Book book { get; set; }
        public int p_id { get; set; }
        public virtual Payment pay { get; set; }
    }
}
