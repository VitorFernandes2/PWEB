using ERecarga.DAL;
using ERecarga.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ERecarga.App_Code
{
    public class ListStationByUserIdEdit
    {
        public static SelectList createListItems(ApplicationDbContext db, string id, int stationId)
        {

            List<SelectListItem> selectListItems = new List<SelectListItem>();
            Station station = db.Stations.Find(stationId);
            selectListItems.Add(new SelectListItem { Text = $"{station.Name}", Value = $"{station.Id}" });

            foreach (var item in db.Stations.ToList())
            {

                if (item.OwnerId.Equals(id) && item.Id != stationId)
                    selectListItems.Add(new SelectListItem { Text = $"{item.Name}", Value = $"{item.Id}" });

            }

            return new SelectList(selectListItems, "Value", "Text");

        }

    }
}