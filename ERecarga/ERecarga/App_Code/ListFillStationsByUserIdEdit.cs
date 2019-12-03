using ERecarga.DAL;
using ERecarga.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ERecarga.App_Code
{
    public class ListFillStationsByUserIdEdit
    {

        public static SelectList createListItems(ApplicationDbContext db, string id, int stationId)
        {

            List<SelectListItem> selectListItems = new List<SelectListItem>();
            FillStation fillStation = db.FillStations.Find(stationId);
            selectListItems.Add(new SelectListItem { Text = $"{fillStation.Name}", Value = $"{fillStation.Id}" });

            foreach (var item in db.FillStations.ToList())
            {

                if (item.Station.OwnerId.Equals(id) && item.Id != stationId)
                    selectListItems.Add(new SelectListItem { Text = $"{item.Name}", Value = $"{item.Id}" });

            }

            return new SelectList(selectListItems, "Value", "Text");

        }

    }
}