using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MotelRoom.Entity
{
    public class ImageRoom
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int idImage { get; set; }
        public int idRoom { get; set; }
        public byte[] image { get; set; }
    }
}
