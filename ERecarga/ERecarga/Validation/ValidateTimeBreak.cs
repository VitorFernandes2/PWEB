using ERecarga.DAL;
using ERecarga.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERecarga.Validation
{
    public class ValidateTimeBreak
    {

        public static bool AlreadyExistsTimeBreak(TimeBreak timeBreak)
        {

            ApplicationDbContext db = new ApplicationDbContext();
            int BeginHora = timeBreak.Begin.Hour;
            int BeginMinutos = timeBreak.Begin.Minute;
            int EndHora = timeBreak.End.Hour;
            int EndMinutos = timeBreak.End.Minute;

            foreach (var item in db.TimeBreaks.ToList())
            {

                int iBeginHora = item.Begin.Hour;
                int iBeginMinutos = item.Begin.Minute;
                int iEndHora = item.End.Hour;
                int iEndMinutos = item.End.Minute;

                if (BeginHora == iBeginHora && BeginMinutos == iBeginMinutos &&
                    EndHora == iEndHora && EndMinutos == iEndMinutos)
                {
                    return true;
                }

            }

            return false;

        }

    }
}