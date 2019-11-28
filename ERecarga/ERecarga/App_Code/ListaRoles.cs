using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ERecarga.App_Code
{
    public class ListaRoles
    {

        public static SelectList createListItems()
        {

            List<SelectListItem> selectListItems = new List<SelectListItem>();


            selectListItems.Add(new SelectListItem { Text = $"Utilizador", Value = $"User" });
            selectListItems.Add(new SelectListItem { Text = $"Proprietário", Value = $"Owner" });


            return new SelectList(selectListItems, "Value", "Text");

        }

    }
}