using ERecarga.DAL;
using ERecarga.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERecarga.Validation
{
    public class ValidateFillStation
    {

        //Se existir algum objecto igual na base de dados retorna true
        public static bool AlreadyExistsFillStation(FillStation fillStation)
        {

            ApplicationDbContext db = new ApplicationDbContext();

            foreach (var item in db.FillStations.ToList())
            {

                if (item.Name.Equals(fillStation.Name) &&
                    item.StationId == fillStation.StationId &&
                    item.Type.Equals(fillStation.Type))
                {
                    return true;
                }

            }

            return false;

        }

    }
}