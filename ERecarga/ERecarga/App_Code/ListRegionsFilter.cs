﻿using ERecarga.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ERecarga.App_Code
{
    public class ListRegionsFilter
    {

        public static SelectList createListItems(ApplicationDbContext db)
        {

            List<SelectListItem> selectListItems = new List<SelectListItem>();

            selectListItems.Add(new SelectListItem { Text = $"Todos", Value = $"*" });

            foreach (var item in db.Regions.ToList())
            {

                selectListItems.Add(new SelectListItem { Text = $"{item.Name}", Value = $"{item.RegionId}" });

            }

            return new SelectList(selectListItems, "Value", "Text");

        }

    }
}