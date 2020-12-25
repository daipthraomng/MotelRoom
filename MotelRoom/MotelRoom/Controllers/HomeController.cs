using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using MotelRoom.Context;
using MotelRoom.Entity;
using MotelRoom.Entity.AddressEntity;
using MotelRoom.IService;
using MotelRoom.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using MotelRoom.Areas.Identity.Data;


namespace MotelRoom.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        public static int idRoom = 5;
        private readonly ILogger<HomeController> _logger;
        private List<Motel> listMotels = new List<Motel>();
        IImageRoomService _imageRoomService = null;
        private readonly DatabaseContext _context;

        public HomeController(ILogger<HomeController> logger, IImageRoomService imageRoomService, DatabaseContext context,UserManager<AppUser> userManager)
        {
            _userManager = userManager;
            _logger = logger;
            listMotels = new List<Motel>()
            {
               new Motel() { MotelID = 101, MotelAvatarImg = "James", MotelTitle = "PHÒNG SẠCH, MỚI, YÊN TĨNH PHÙ HỢP VỚI EDITOR, DIGITAL MARKETING", MotelPrice = "111USD", MotelLocation = "HoTungMau", MotelContent = "PhuHopOffice", MotelUpdateTime = "1-1-2020" },
               new Motel() { MotelID = 102, MotelAvatarImg = "James", MotelTitle = "Vip2", MotelPrice = "222USD", MotelLocation = "XuanThuy", MotelContent = "PhuHopOffice", MotelUpdateTime = "1-1-2020" },
               new Motel() { MotelID = 103, MotelAvatarImg = "James", MotelTitle = "Vip3", MotelPrice = "222USD", MotelLocation = "CauGiay", MotelContent = "PhuHopOffice", MotelUpdateTime = "1-1-2020" }
            };

            _imageRoomService = imageRoomService;
            _context = context;
        }
        public IActionResult Index()
        {
            //var userId = _userManager.GetUserId(HttpContext.User);
            //var user =  await _userManager.FindByIdAsync(userId);
            var objListRoom = new RoomInfoModel();
            objListRoom.GetListRoomSummaryInfo();
            foreach (var item in objListRoom.listRoomSummary)
            {
                string imageBase64Data = Convert.ToBase64String(item.image);
                item.srcImage = string.Format("data:image/jpg;base64,{0}", imageBase64Data);
            }
            //var userRoles = await _userManager.GetRolesAsync(user);
            //var role = userRoles[0];
            //if (role == "Admin")
            //{
            //    return RedirectToAction("AdminScreen", "Home");
            //}
            //else if (role == "Owner")
            //{
            //    return RedirectToAction("HostScreen", "Home");
            //}
            //else
            //{
            //    return View(objListRoom);
            //}
            return View(objListRoom);
        }

        public IActionResult RoomInfo(int idRoom)
        {
            var roomInfoModel = new RoomInfoModel();

            //roomInfoModel.GetRoomInfo(idRoom);
            var listRoom = _context.Rooms.ToList();
            roomInfoModel.objRoom = listRoom.Where(x => x.idRoom == idRoom).ToList()[0];
            roomInfoModel.listImageRoom = _context.ImageRooms.ToList().Where(x => x.idRoom == idRoom).ToList();
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
        [Authorize(Roles ="Owner")]
        public IActionResult HostScreen()
        {
            return View();
        }
        [Authorize(Roles = "Owner")]
        public IActionResult PostNews()
        {
            var addressModel = new AddressModel();
            addressModel.listProvince = _context.Provinces.ToList();
            return View(addressModel);
        }
        [HttpPost]
         [Authorize(Roles = "Owner")]
        public PostNews PostPostNews([FromBody] PostNews obj)
        {
            PostNewsModel pn = new PostNewsModel();
            pn.PostPostNews(obj);
            return obj;
        }
        [HttpGet]
        public JsonResult GetDistrictList(int idProvince)
        {
            var districts = _context.Districts.ToList();
            var selectedDistricts = districts.Where(x => x.idProvince == idProvince).ToList();
            return Json(new SelectList(selectedDistricts, "idDistrict", "name"));

        }
        [HttpGet]
        public JsonResult GetWardList(int idDistrict)
        {
            var wards = _context.Wards.ToList();
            var selectedWards = wards.Where(x => x.idDistrict == idDistrict).ToList();
            return Json(new SelectList(selectedWards, "idWard", "name"));

        }
        [HttpGet]
        public JsonResult GetStreetList(int idDistrict)
        {
            var streets = _context.Streets.ToList();
            var selectedStreets = streets.Where(x => x.idDistrict == idDistrict).ToList();
            return Json(new SelectList(selectedStreets, "idStreet", "name"));
        }
        [HttpPost]
        public async Task<IActionResult> HostScreen(List<IFormFile> files)
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
         [Authorize(Roles = "Owner")]   
        public IActionResult PendingMotel()
        {
            return View();
        }
        [Authorize(Roles = "Owner")]
        public IActionResult CheckedMotel()
        {
            return View();
        }

        public IActionResult ClientScreen()
        {
            var objListRoom = new ClientScreenModel();
            objListRoom.GetListRoomSummaryInfo();
            objListRoom.objAddress.listProvince = _context.Provinces.ToList();
            foreach (var item in objListRoom.listRoomSummary)
            {
                string imageBase64Data = Convert.ToBase64String(item.image);
                item.srcImage = string.Format("data:image/jpg;base64,{0}", imageBase64Data);
            }
            return View(objListRoom);
        }
        [HttpPost]
        public IActionResult ClientScreen([FromBody] SearchRoom obj)
        {
            var objListRoom = new ClientScreenModel();
            objListRoom.SearchListRoomSummary(obj);
            objListRoom.objAddress.listProvince = _context.Provinces.ToList();
            foreach (var item in objListRoom.listRoomSummary)
            {
                string imageBase64Data = Convert.ToBase64String(item.image);
                item.srcImage = string.Format("data:image/jpg;base64,{0}", imageBase64Data);
            }
            return View(objListRoom);
        }
        //[HttpGet]
        //public JsonResult ClientScreen([FromBody] SearchRoom obj)
        //{
        //    ClientScreenModel objSearchRoom = new ClientScreenModel();
        //    objSearchRoom.SearchListRoomSummary(obj);
        //    return obj;
        //}
        [Authorize(Roles ="Admin")]
        public IActionResult AdminScreen()
        {
            return View();
        }
           [Authorize(Roles = "Admin")]
        public IActionResult AdminCheckedMotel()
        {
            return View();
        }
        [Authorize(Roles = "Admin")]
        public IActionResult AdminPendingMotel()
        {
            return View();
        }   
        [Authorize(Roles = "Admin")]
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