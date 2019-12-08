using ERecarga.DAL;
using ERecarga.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ERecarga.ViewModels
{
    public class ReservationViewModel
    {

        [Required]
        public int FillStationTimeBreakId { get; set; }
        [Required]
        public FillStationTimeBreak FillStationTimeBreak { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime Day { get; set; }
        [Required]
        public double Price { get; set; }

    }
}