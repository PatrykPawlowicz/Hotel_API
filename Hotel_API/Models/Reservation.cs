using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.VisualBasic;
using System;


namespace Hotel_API.Models
{
        public class Reservation
        {
            [Key]
            [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            public decimal id_reservation { get; set; }
            public DateTime start_date { get; set; }
            public DateTime end_date { get; set; }
            public decimal id_user { get; set; }
            public decimal id_room { get; set; }
        }
}
