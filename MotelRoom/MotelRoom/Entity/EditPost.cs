using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MotelRoom.Entity
{
    public class EditPost
    {
        public string idRoom { get; set; }
        public string title { get; set; }
        public string idProvince { get; set; }
        public string idDistrict { get; set; }
        public string idWard { get; set; }
        public string idStreet { get; set; }
        public string homeNo { get; set; }
        public string publicPlaceAround { get; set; }
        public string typeRoom { get; set; }
        public string roomNo { get; set; }
        public string price { get; set; }
        public string area { get; set; }
        //// TODO: thuộc tính trả theo (1 tháng/ 3 tháng...)
        public string bathroom { get; set; }
        public string heater { get; set; }
        public string kitchen { get; set; }
        public string airCondition { get; set; }
        public string balcony { get; set; }
        //// TODO: Điện nước giá dân/ giá thuê chưa cho vào và có cần ko?
        public string electricityPrice { get; set; }
        public string waterPrice { get; set; }
        public string otherUtility { get; set; }
        public string description { get; set; }
        public string timeDisplay { get; set; }
        public string unitTimeId { get; set; }
    }
}
