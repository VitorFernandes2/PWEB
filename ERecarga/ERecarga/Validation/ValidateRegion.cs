using ERecarga.DAL;
using ERecarga.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERecarga.Validation
{
    public class ValidateRegion
    {

        //Se existir algum objecto igual na base de dados retorna true
        public static bool AlreadyExistsRegion(Region region)
        {

            ApplicationDbContext db = new ApplicationDbContext();

            foreach (var item in db.Regions.ToList())
            {

                if (item.Name.Equals(region.Name))
                {
                    return true;
                }

            }

            return false;

        }

    }
}