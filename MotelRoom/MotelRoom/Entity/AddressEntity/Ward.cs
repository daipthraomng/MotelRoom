using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MotelRoom.Entity.AddressEntity
{
    public class Ward
    {
        public int idWard { get; set; }
        public string name { get; set; }
        public string prefix { get; set; }
        public int idProvince{ get; set; }
        public int idDistrict { get; set; }
    }
}
