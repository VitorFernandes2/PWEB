using ERecarga.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERecarga.App_Code
{
    public class VerifyPromotion
    {

        public static double verifyPrice(ApplicationDbContext db, DateTime date, int fillStationId)
        {

            double price = 0;
            var listPromotions = db.Promotions.ToList();

            foreach(var item in listPromotions)
            {

                if(item.PromotionStart.Date <= date.Date &&
                   item.PromotionEnd.Date >= date.Date && 
                   item.FillStationId == fillStationId)
                {

                    price = item.Price;
                    break;

                }

            }

            if(price == 0)
            {
                price = db.FillStations.Find(fillStationId).Price;
            }

            return price;

        }

    }
}