using ERecarga.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Web.Mvc;

namespace ERecarga.Controllers
{
    public class StatisticsController : Controller
    {
        // GET: Statistics
        public ActionResult Index()
        {
            List<DataPoint> dataPoints = new List<DataPoint>();

            dataPoints.Add(new DataPoint("Samsung", 25));
            dataPoints.Add(new DataPoint("Micromax", 13));
            dataPoints.Add(new DataPoint("Lenovo", 8));
            dataPoints.Add(new DataPoint("Intex", 7));
            dataPoints.Add(new DataPoint("Reliance", 6.8));
            dataPoints.Add(new DataPoint("Others", 40.2));

            ViewBag.DataPoints = JsonConvert.SerializeObject(dataPoints);

            return View();
        }
    }
}