using System.Collections.Generic;

namespace Hotel_API.Models
    {
        public class User
        {
            public int id { get; set; }
            public string name { get; set; }
            public string surname { get; set; }
            public string email { get; set; }
            public byte[] passwordHash { get; set; }
            public byte[] passwordSalt { get; set; }
            public List<Reservation> reservations { get; set; }
            public List<Room> rooms { get; set; }
        }
    }