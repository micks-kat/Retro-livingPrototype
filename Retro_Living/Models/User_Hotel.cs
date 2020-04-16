using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Retro_Living.Models
{
    public class User_Hotel
    {
        [JsonProperty("user_id")]
        public int user_id { get; set; }
        [ForeignKey("user_id")]
        public virtual User user { get; set; }

        [JsonProperty("h_id")]
        public int h_id { get; set; }
        [ForeignKey("h_id")]
        public virtual Hotel hotel { get; set; }
    }
}
