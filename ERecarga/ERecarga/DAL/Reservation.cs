using ERecarga.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ERecarga.DAL
{
    public partial class Reservation
    {

        public int Id { get; set; }
        [ForeignKey("ApplicationUser")]
        public string UserId { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
        [ForeignKey("FillStationTimeBreak")]
        public int FillStationTimeBreakId { get; set; }
        public virtual FillStationTimeBreak FillStationTimeBreak { get; set; }
        [DataType(DataType.Date)]
        public DateTime Day { get; set; }
        public double Price { get; set; }
        public bool State { get; set; }

    }
}