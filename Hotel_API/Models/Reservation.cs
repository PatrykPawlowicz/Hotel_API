using System.Collections.Generic;


namespace Hotel_API.Models
{
        public class Reservation
        {
            public int id { get; set; }
            public string duration { get; set; }
            public User user { get; set; }
            public Room room { get; set; }
        }
}
