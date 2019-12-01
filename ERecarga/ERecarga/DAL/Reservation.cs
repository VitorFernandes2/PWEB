using ERecarga.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ERecarga.DAL
{
    public partial class Reservation
    {

        public int Id { get; set; }
        public ApplicationUser User { get; set; }
        public FillStationTimeBreak FillStationTimeBreak { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime Day { get; set; }
        public double Price { get; set; }
        public bool State { get; set; }

    }
}