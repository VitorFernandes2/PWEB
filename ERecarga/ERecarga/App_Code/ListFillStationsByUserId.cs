using ERecarga.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ERecarga.App_Code
{
    public class ListFillStationsByUserId
    {

        public static SelectList createListItems(ApplicationDbContext db, string id)
        {

            List<SelectListItem> selectListItems = new List<SelectListItem>();

            foreach (var item in db.FillStations.ToList())
            {

                if (item.Station.OwnerId.Equals(id))
                    selectListItems.Add(new SelectListItem { Text = $"{item.Name}", Value = $"{item.Id}" });

            }

            return new SelectList(selectListItems, "Value", "Text");

        }

    }
}