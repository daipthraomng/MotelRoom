using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MotelRoom.Entity;
using MotelRoom.IService;
using MotelRoom.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;


namespace MotelRoom.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        public static int idRoom = 5;
        private readonly ILogger<HomeController> _logger;
        private List<Motel> listMotels = new List<Motel>();
        private RoomInfoModel roomInfoModel;
        IImageRoomService _imageRoomService = null;

        public HomeController(ILogger<HomeController> logger, IImageRoomService imageRoomService)
        {
            _logger = logger;
            listMotels = new List<Motel>()
            {
               new Motel() { MotelID = 101, MotelAvatarImg = "James", MotelTitle = "PHÒNG SẠCH, MỚI, YÊN TĨNH PHÙ HỢP VỚI EDITOR, DIGITAL MARKETING", MotelPrice = "111USD", MotelLocation = "HoTungMau", MotelContent = "PhuHopOffice", MotelUpdateTime = "1-1-2020" },
               new Motel() { MotelID = 102, MotelAvatarImg = "James", MotelTitle = "Vip2", MotelPrice = "222USD", MotelLocation = "XuanThuy", MotelContent = "PhuHopOffice", MotelUpdateTime = "1-1-2020" },
               new Motel() { MotelID = 103, MotelAvatarImg = "James", MotelTitle = "Vip3", MotelPrice = "222USD", MotelLocation = "CauGiay", MotelContent = "PhuHopOffice", MotelUpdateTime = "1-1-2020" }
            };

            roomInfoModel = new RoomInfoModel();
            _imageRoomService = imageRoomService;
        }

        public IActionResult Index()
        {
            return View(listMotels);
        }
        public IActionResult RoomInfo()
        {
            roomInfoModel.GetRoomInfo(1);
            return View(roomInfoModel);
        }
        public IActionResult ImageRoom()
        {
            var ImageRoom = new ImageRoomModel();
            ImageRoom.GetImageRoom(1);
            return View(ImageRoom);
        }
        [HttpPost("FileUpload")]
        public async Task<IActionResult> ImageRoom(List<IFormFile> files)
        {
            Thread.Sleep(2000);
            var size = files.Sum(f => f.Length);
            var filePaths = new List<String>();
            foreach (var formFile in files)
            {
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), formFile.FileName);
                filePaths.Add(filePath);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await formFile.CopyToAsync(stream);
                }

            }
            return View();
        }
        
        public IActionResult SignIn()
        {
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }

        public IActionResult RegisterForHost()
        {
            return View();
        }

        public IActionResult HostScreen()
        {
            return View();
        }

        public IActionResult PostNews()
        {
            // Đừng xóa phần này nhé ^^
            //var addressModel = new AddressModel();
            //addressModel.GetListProvince();
            //return View(addressModel);

            return View();
        }
        [HttpPost]
        public PostNews PostNews([FromBody] PostNews obj)
        {
            PostNewsModel pn = new PostNewsModel();
            pn.PostPostNews(obj);
            //ImageRoomModel objImageRoom = new ImageRoomModel();
            //objImageRoom.PostImageRoom(1, "C:\\fakepath\\ghinhan mon.png");
            return obj;
        }
        [HttpPost("UploadImageRoom")]
        public async Task<IActionResult> PostNews(List<IFormFile> files)
        {
            var size = files.Sum(f => f.Length);
            var filePaths = new List<String>();
            foreach (var formFile in files)
            {
                ImageRoom img = new ImageRoom();
                using (var ms = new MemoryStream())
                {
                    await formFile.CopyToAsync(ms);
                    img.image = ms.ToArray();
                    img.idRoom = HomeController.idRoom;
                    img = _imageRoomService.Save(img);
                }

            }
            return View();
        }
        public IActionResult PendingMotel()
        {
            return View();
        }

        public IActionResult CheckedMotel()
        {
            return View();
        }

        public IActionResult ClientScreen()
        {
            return View(listMotels);
        }

        public IActionResult AdminScreen()
        {
            return View();
        }

        public IActionResult AdminCheckedMotel()
        {
            return View();
        }

        public IActionResult AdminPendingMotel()
        {
            return View();
        }
        public IActionResult AdminRejectedMotel()
        {
            return View();
        }

        public IActionResult Detail(int ID)
        {
            var motelDetails = listMotels.FirstOrDefault(std => std.MotelID == ID);
            return View(motelDetails);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}