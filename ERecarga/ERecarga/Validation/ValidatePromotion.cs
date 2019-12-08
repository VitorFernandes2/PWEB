using ERecarga.DAL;
using ERecarga.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERecarga.Validation
{
    public class ValidatePromotion
    {

        //Se existir algum objecto igual na base de dados retorna true
        public static bool AlreadyExistsPromotion(Promotion promotion)
        {

            ApplicationDbContext db = new ApplicationDbContext();

            foreach (var item in db.Promotions.ToList())
            {

                if (item.FillStationId == promotion.FillStationId &&
                    item.PromotionEnd.Date == promotion.PromotionEnd.Date &&
                    item.PromotionStart.Date == promotion.PromotionStart.Date)
                {
                    return true;
                }

            }

            return false;

        }

    }
}