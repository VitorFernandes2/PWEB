using ERecarga.Models;
using ERecarga.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERecarga.App_Code
{
    public class ListReservationViewModel
    {

        public static List<ReservationViewModel> createListItems(ApplicationDbContext db)
        {

            List<ReservationViewModel> ListReservations = new List<ReservationViewModel>();

            foreach (var item in db.FillStationTimeBreaks.ToList())
            {


                ReservationViewModel reservationViewModel = new ReservationViewModel();
                reservationViewModel.Day = DateTime.Today;
                reservationViewModel.FillStationTimeBreak = item;
                reservationViewModel.FillStationTimeBreakId = item.Id;

                int count = 0;

                foreach (var item2 in db.Promotions)
                {

                    if (item.FillStationId == item2.FillStationId &&
                        item2.PromotionEnd.Date >= DateTime.Now)
                    {

                        reservationViewModel.Price = item2.Price;

                    }

                }

                if (count == 0)
                    reservationViewModel.Price = item.FillStation.Price;

                ListReservations.Add(reservationViewModel);

            }

            return ListReservations;

        }

    }

}