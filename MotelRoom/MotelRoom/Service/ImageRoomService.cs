using MotelRoom.Context;
using MotelRoom.Entity;
using MotelRoom.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MotelRoom.Service
{
    public class ImageRoomService : IImageRoomService
    {
        private readonly DatabaseContext _context;
        public ImageRoomService(DatabaseContext context)
        {
            _context = context;
        }
        public ImageRoom Save(ImageRoom objImageRoom)
        {
            _context.ImageRooms.Add(objImageRoom);
            _context.SaveChanges();
            return objImageRoom;
        }
        public ImageRoom GetSavedImageRoom()
        {
            return _context.ImageRooms.OrderByDescending(e => e.idImage).FirstOrDefault();
        }
    }
}
