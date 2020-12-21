using MotelRoom.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MotelRoom.IService
{
    public interface IImageRoomService
    {
        ImageRoom Save(ImageRoom objImageRoom);
        ImageRoom GetSavedImageRoom();
    }
}
