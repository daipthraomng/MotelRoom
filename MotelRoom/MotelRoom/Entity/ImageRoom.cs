using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MotelRoom.Entity
{
    public class ImageRoom
    {
        public int idImage { get; set; }
        public int idRoom { get; set; }
        public byte[] image { get; set; }
    }
}
