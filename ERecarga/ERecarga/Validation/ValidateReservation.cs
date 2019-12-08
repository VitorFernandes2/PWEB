using ERecarga.DAL;
using ERecarga.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERecarga.Validation
{
    public class ValidateReservation
    {

        //Se existir algum objecto igual na base de dados retorna true
        public static bool AlreadyExistsReservation(Reservation reservation)
        {

            ApplicationDbContext db = new ApplicationDbContext();

            if (reservation.Day.Date < DateTime.Now.Date)
            {
                return true;
            }
            else //se o dia for o atual
                if(reservation.Day.Date == DateTime.Now.Date)
            {

                int hour = DateTime.Now.Hour;
                int minutes = DateTime.Now.Minute;

                int reservationMinute = reservation.FillStationTimeBreak.TimeBreak.Begin.Minute;
                int reservationHour = reservation.FillStationTimeBreak.TimeBreak.Begin.Hour;

                //Verifica a hora a ver se a hora inserida é maior
                if (hour < reservationHour || 
                    (hour == reservationHour && minutes <= reservationMinute))
                {

                    return true;

                }

            }

            foreach (var item in db.Reservations.ToList())
            {

                //Se alguém já reservou para aquela hora naquele dia, naquele dia
                //retorna true
                if(item.Day == reservation.Day && 
                    item.FillStationTimeBreakId == reservation.FillStationTimeBreakId)
                {
                    return true;
                }

            }

            return false;

        }

    }
}