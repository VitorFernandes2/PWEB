using ERecarga.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ERecarga.Validation
{
    public class Validate
    {

        public class Positivo : ValidationAttribute
        {

            public override bool IsValid(object value)
            {
                if (value is float)
                    if (float.TryParse(value.ToString(), out float num))
                        if (num >= 0) return true;

                return false;
            }
        }


        public class ExistAlreadyPost : ValidationAttribute
        {

            private ApplicationDbContext db = new ApplicationDbContext();
            public override bool IsValid(object value)
            {
                if (value is string)
                {
                    foreach (var val in db.FillStations)
                    {
                        if (val.Name.Equals(value))
                            return false;

                    }
                }

                return false;
            }

        }



    }
}