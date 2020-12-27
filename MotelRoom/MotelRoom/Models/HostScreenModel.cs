using MotelRoom.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MotelRoom.Models
{
    public class HostScreenModel:BaseModel
    {
        public List<Message> listMessage { get; set; }

        public HostScreenModel()
        {
            this.listMessage = new List<Message>();
        }
    }
}
