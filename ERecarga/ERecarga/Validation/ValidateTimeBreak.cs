using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERecarga.Validation
{
    public class ValidateTimeBreak
    {
        public static bool AlreadyExistsTimeBreak(FillStationTimeBreak fillStationTimeBreak)
        {

            ApplicationDbContext db = new ApplicationDbContext();

            foreach (var item in db.FillStationTimeBreaks.ToList())
            {

                if (item.FillStationId == fillStationTimeBreak.FillStationId && item.TimeBreakId == fillStationTimeBreak.TimeBreakId)
                {
                    return true;
                }

            }

            return false;

        }

    }
}