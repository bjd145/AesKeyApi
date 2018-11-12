using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using aeskeyui.Models;
using System.Net.Http;
using System.Net;

namespace aeskeyui.Controllers
{
    public class HomeController : Controller
    {
        public async Task<IActionResult> Index()
        {
			string result = "";
			try {
				IPHostEntry hostInfo = Dns.GetHostEntry("aeskeyapisvc.default.svc.cluster.local");
				Uri uri = new Uri("http://aeskeyapisvc.default.svc.cluster.local/api/keys");
				HttpClient client = new HttpClient();
				var response =  await client.GetAsync(uri);
				result = await response.Content.ReadAsStringAsync();
				ViewData["Message"] = "Hosts " + hostInfo.AddressList[0].ToString() + ". Result " +  result;
			}
			catch (Exception e) {
				ViewData["Message"] = "Got the following error" + e.Message;
			}

            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
