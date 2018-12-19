using System;

namespace FlightandHotel.Models
{
    public class FlightAndHotel
    {
        //tickets that we will get 
        public int ID { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }
        public string Email { get; set; }
        public string Details { get; set; } // will get this from our external API
    }
}