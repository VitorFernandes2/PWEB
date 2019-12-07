using ERecarga.DAL;
using ERecarga.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ERecarga.App_Code
{
    public class ListStationByUserId
    {

        public static SelectList createListItems(ApplicationDbContext db, string id)
        {

            List<SelectListItem> selectListItems = new List<SelectListItem>();

            foreach (var item in db.Stations.ToList())
            {

                if (item.OwnerId.Equals(id))
                    selectListItems.Add(new SelectListItem { Text = $"{item.Name}", Value = $"{item.Id}" });

            }

            return new SelectList(selectListItems, "Value", "Text");

        }

        public static SelectList createallListItems(ApplicationDbContext db)
        {

            List<SelectListItem> selectListItems = new List<SelectListItem>();

            foreach (var item in db.Stations.ToList())
            {

                    selectListItems.Add(new SelectListItem { Text = $"{item.Name}", Value = $"{item.Id}" });

            }

            return new SelectList(selectListItems, "Value", "Text");

        }

    }
}