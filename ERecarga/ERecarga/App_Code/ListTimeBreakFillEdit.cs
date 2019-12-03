using ERecarga.DAL;
using ERecarga.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ERecarga.App_Code
{
    public class ListTimeBreakFillEdit
    {

        public static SelectList createListItems(ApplicationDbContext db, int id)
        {

            List<SelectListItem> selectListItems = new List<SelectListItem>();
            TimeBreak timeBreak = db.TimeBreaks.Find(id);
            selectListItems.Add(new SelectListItem { Text = $"Das {timeBreak.Begin.ToString("HH:mm")} às {timeBreak.End.ToString("HH:mm")}", Value = $"{timeBreak.TimeBreakId}" });

            foreach (var item in db.TimeBreaks.ToList())
            {

                if(item.TimeBreakId != id)
                    selectListItems.Add(new SelectListItem { Text = $"Das {item.Begin.ToString("HH:mm")} às {item.End.ToString("HH:mm")}", Value = $"{item.TimeBreakId}" });

            }

            return new SelectList(selectListItems, "Value", "Text");

        }

    }
}