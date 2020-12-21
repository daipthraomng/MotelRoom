using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace MotelRoom.Controllers
{
    public class PostNewsController : Controller
    {
        HttpClientHandler _clientHandler = new HttpClientHandler();

        public PostNewsController()
        {
            _clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
        }

        // GET: PostNewsController
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public async Task<string> GetAllEmployees()
        {
            using (var httpClient = new HttpClient(_clientHandler))
            {
                using (var response = await httpClient.GetAsync("http://localhost:55137/WeatherForecast"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                }
            }
            return "getCon";
        }

        // POST: PostNewsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PostNewsController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PostNewsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PostNewsController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PostNewsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
