using ERecarga.DAL;
using ERecarga.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERecarga.Validation
{
    public class ValidateFillStationTimeBreak
    {

        //Se existir algum objecto igual na base de dados retorna true
        public static bool AlreadyExistsFillStationTimeBreak(FillStationTimeBreak fillStationTimeBreak)
        {

            ApplicationDbContext db = new ApplicationDbContext();

            foreach (var item in db.FillStationTimeBreaks.ToList())
            {

                if(item.FillStationId == fillStationTimeBreak.FillStationId &&
                    item.TimeBreakId == fillStationTimeBreak.TimeBreakId)
                {
                    return true;
                }

            }

            return false;

        }

    }
}