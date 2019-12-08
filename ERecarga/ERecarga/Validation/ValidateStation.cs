using ERecarga.DAL;
using ERecarga.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERecarga.Validation
{
    public class ValidateStation
    {
        public static bool AlreadyExistsStation(Station station)
        {

            ApplicationDbContext db = new ApplicationDbContext();

            foreach (var item in db.Stations.ToList())
            {

                if (item.Name.Equals(station.Name))
                {
                    return true;
                }

            }

            return false;

        }
    }
}