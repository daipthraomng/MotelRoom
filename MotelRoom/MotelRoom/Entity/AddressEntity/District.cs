using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MotelRoom.Entity.AddressEntity
{
    public class District
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int idDistrict { get; set; }
        public string name { get; set; }
        public string prefix { get; set; }
        public int idProvince{ get; set; }
    }
}
