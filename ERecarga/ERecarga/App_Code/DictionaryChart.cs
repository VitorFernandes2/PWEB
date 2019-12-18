using ERecarga.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERecarga.App_Code
{
    public class DictionaryChart
    {

        public static Dictionary<string, int> createListItems(ApplicationDbContext db, string userId)
        {

            Dictionary<string, int> dictionaryChart = new Dictionary<string, int>();

            var reservations = db.Reservations.ToList();

            foreach(var item in reservations.ToList())
            {

                if(item.FillStationTimeBreak.FillStation.Station.OwnerId.Equals(userId))
                {

                    if (dictionaryChart.ContainsKey(item.FillStationTimeBreak.FillStation.Name))
                    {

                        foreach (var item2 in dictionaryChart)
                        {
                            if (item2.Key.Equals(item.FillStationTimeBreak.FillStation.Name))
                            {
                                dictionaryChart[item2.Key] = item2.Value + 1;
                                break;
                            }                                
                        }

                    } else
                    {

                        dictionaryChart.Add(item.FillStationTimeBreak.FillStation.Name, 1);

                    }

                }

            }

            return dictionaryChart;

        }

    }
}