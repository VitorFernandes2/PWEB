using ERecarga.App_Code;
using ERecarga.Models;
using Microsoft.AspNet.Identity;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Web.Mvc;

namespace ERecarga.Controllers
{
    public class StatisticsController : Controller
    {

        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Statistics
        [Authorize(Roles = "Owner")]
        public ActionResult Index()
        {
            List<DataPoint> dataPoints = new List<DataPoint>();

            string userid = User.Identity.GetUserId();
            Dictionary<string, int> dict = DictionaryChart.createListItems(db, userid);

            foreach(var item in dict)
            {
                dataPoints.Add(new DataPoint(item.Key, dict[item.Key]));
            }

            //dataPoints.Add(new DataPoint("Samsung", 25));
            //dataPoints.Add(new DataPoint("Micromax", 13));
            //dataPoints.Add(new DataPoint("Lenovo", 8));
            //dataPoints.Add(new DataPoint("Intex", 7));
            //dataPoints.Add(new DataPoint("Reliance", 6.8));
            //dataPoints.Add(new DataPoint("Others", 40.2));

            ViewBag.DataPoints = JsonConvert.SerializeObject(dataPoints);

            return View();
        }
    }
}