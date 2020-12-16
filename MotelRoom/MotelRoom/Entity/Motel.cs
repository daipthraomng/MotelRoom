using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MotelRoom.Models
{
    public class Motel
    {
        public int MotelID { get; set; }
        public String MotelAvatarImg { get; set; }
        public String MotelTitle { get; set; }
        public String MotelPrice { get; set; }
        public String MotelLocation { get; set; }
        public String MotelContent { get; set; }
        public String MotelUpdateTime { get; set; }

    }
}