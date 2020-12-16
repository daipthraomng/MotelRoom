using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MotelRoom.Models
{
    public class Room
    {
        public int idRoom { get; set; }
        [Column(TypeName = "decimal(10, 2)")]
        public decimal price { get; set; }
        [Column(TypeName = "decimal(10, 2)")]
        public decimal area { get; set; }
    }
}
