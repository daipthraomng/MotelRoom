using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MotelRoom.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MotelRoom.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private List<Motel> listMotels = new List<Motel>();

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            listMotels = new List<Motel>()
            {
               new Motel() { MotelID = 101, MotelAvatarImg = "James", MotelTitle = "Vip1", MotelPrice = "111USD", MotelLocation = "HoTungMau", MotelContent = "PhuHopOffice", MotelUpdateTime = "1-1-2020" },
               new Motel() { MotelID = 102, MotelAvatarImg = "James", MotelTitle = "Vip2", MotelPrice = "222USD", MotelLocation = "XuanThuy", MotelContent = "PhuHopOffice", MotelUpdateTime = "1-1-2020" },
               new Motel() { MotelID = 103, MotelAvatarImg = "James", MotelTitle = "Vip3", MotelPrice = "222USD", MotelLocation = "CauGiay", MotelContent = "PhuHopOffice", MotelUpdateTime = "1-1-2020" }
            };
        }

        public IActionResult Index()
        {
            return View(listMotels);
        }

        public IActionResult Privacy()
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
