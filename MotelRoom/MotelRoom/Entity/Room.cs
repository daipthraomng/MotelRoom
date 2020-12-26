using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MotelRoom.Models
{
    public class Room
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int idRoom { get; set; }
        public string title { get; set; }
        public int price { get; set; }
        public int area { get; set; }
        public string typeRoom { get; set; }
        public int roomNo { get; set; }
        public string homeNo { get; set; }
        public int idProvince { get; set; }
        public int idDistrict { get; set; }
        public int idWard { get; set; }
        public int idStreet { get; set; }
        public string? publicPlaceAround { get; set; }
        public string bathroom { get; set; }
        public string heater { get; set; }
        public string kitchen { get; set; }
        public string airCondition { get; set; }
        public string balcony { get; set; }
        public int electricityPrice { get; set; }
        public int waterPrice { get; set; }
        public string? otherUtility { get; set; }
        public string? description { get; set; }
        public int timeDisplay { get; set; }
        public int unitTimeId { get; set; }
        public string? statusRent { get; set; }
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime infoUpdateTime { get; set; }
        public string? statusCheck { get; set; }
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime? timeStartPost { get; set; }
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime? timeEndPost { get; set; }
        public string? statusEdit { get; set; }
        public int? viewAmount { get; set; }
        public int? likeAmount { get; set; }
    }
}
