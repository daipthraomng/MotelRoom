using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MotelRoom.Entity
{
    public class RoomSummaryInfo
    {
        public int idRoom { get; set; }
        public string title { get; set; }
        public int price { get; set; }
        public int area { get; set; }
        public string provinceName { get; set; }
        public string districtName { get; set; }
        public string wardName { get; set; }
        public string streetName { get; set; }
        public string description { get; set; }
        public int numberDayPosted { get; set; }
        public byte[] image { get; set; }
        public string srcImage { get; set; }
    }
}
