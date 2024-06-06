using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Hotel_API.Models
    {
        public class User
        {
            [Key]
            [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            public decimal id_user { get; set; }
            public string name { get; set; }
            public string surname { get; set; }
            public string email { get; set; }
            public byte[] passwordHash { get; set; }
            public byte[] passwordSalt { get; set; }
        }
    }