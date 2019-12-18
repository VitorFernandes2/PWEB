using ERecarga.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ERecarga.App_Code
{
    public class ListTimeBreakFilter
    {

        public static SelectList createListItems(ApplicationDbContext db)
        {

            List<SelectListItem> selectListItems = new List<SelectListItem>();
            selectListItems.Add(new SelectListItem { Text = $"Todos", Value = $"*" });


            foreach (var item in db.TimeBreaks.ToList())
            {

                selectListItems.Add(new SelectListItem { Text = $"Das {item.Begin.ToString("HH:mm")} às {item.End.ToString("HH:mm")}", Value = $"{item.TimeBreakId}" });

            }

            return new SelectList(selectListItems, "Value", "Text");

        }

    }
}