using ERecarga.DAL;
using ERecarga.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ERecarga.App_Code
{
    public class ListRegionsById
    {

        public static SelectList createListItems(ApplicationDbContext db, int? id)
        {

            List<SelectListItem> selectListItems = new List<SelectListItem>();

            Region region = db.Regions.Find(id);

            selectListItems.Add(new SelectListItem { Text = $"{region.Name}", Value = $"{region.RegionId}" });

            foreach (var item in db.Regions.ToList())
            {

                if(item.RegionId != id)
                    selectListItems.Add(new SelectListItem { Text = $"{item.Name}", Value = $"{item.RegionId}" });
                
            }

            return new SelectList(selectListItems, "Value", "Text");

        }

    }
}