using System.Collections.Generic;

namespace Hotel_API.Models
{
        public class Room
        {
            public int id { get; set; }
            public string number { get; set; }
            public string description { get; set; }
            public User user { get; set; }

        }
}
