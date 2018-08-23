using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MediaRepo.Models;
using Newtonsoft.Json;

namespace MediaRepo.Controllers
{
    public class MovieController : Controller
    {
        public ActionResult Search()
        {
            ViewBag.Title = "SearchMovie";
            return View();            
        }

        public ActionResult GetMovie()
        {
            var searchText = Request["SearchText"];
            ViewBag.Title = "GetMovie";

            string apiKey = "99d5d9ca";
            HttpWebRequest apiRequest = WebRequest.Create("http://www.omdbapi.com/?t=" + searchText + "&apikey=" + apiKey) as HttpWebRequest;
            
            string apiResponse = "";
            if (apiRequest != null)
                using (HttpWebResponse response = apiRequest.GetResponse() as HttpWebResponse)
                {
                    if (response != null)
                    {
                        StreamReader reader = new StreamReader(response.GetResponseStream());
                        apiResponse = reader.ReadToEnd();
                    }
                }

            Movie movieObj = JsonConvert.DeserializeObject<Movie>(apiResponse);
            if (movieObj.Title == null){
                return Content("No Movies Found. Please Visit again for latest movies");
            }
            return View(movieObj);
        }
    }
}