using ERecarga.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ERecarga.App_Code
{
    public class ListOwners
    {

        public static SelectList createListItems(ApplicationDbContext db)
        {

            List<SelectListItem> selectListItems = new List<SelectListItem>();


            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(new ApplicationDbContext()));
            var usersInRole = db.Users.Where(u => u.Roles.Select(r => r.RoleId).Contains("aafc09b0-007c-4a08-bfb2-cf5efeb88ccb")).ToList();

            foreach (var item in usersInRole)
            {

                selectListItems.Add(new SelectListItem { Text = $"{item.Email}", Value = item.Id });

            }

            return new SelectList(selectListItems, "Value", "Text");

        }

    }
}