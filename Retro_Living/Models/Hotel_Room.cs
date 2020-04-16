using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Retro_Living.Models
{
    public class Hotel_Room
    {

        [JsonProperty("h_id")]
        public int h_id { get; set; }
        [ForeignKey("h_id")]
        public Hotel hotel { get; set; }


        [JsonProperty("room_id")]
        public int room_id { get; set; }
        [ForeignKey("room_id")]
        public Room room { get; set; }


    }
}
