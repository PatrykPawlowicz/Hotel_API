using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Hotel_API.Models
{
        public class Room
        {
            [Key]
            [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            public decimal id_room { get; set; }
            public string number { get; set; }
            public string description { get; set; }
        }
}
