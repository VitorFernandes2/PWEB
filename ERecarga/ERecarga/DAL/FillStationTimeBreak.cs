using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ERecarga.DAL
{
    public partial class FillStationTimeBreak
    {

        public int Id { get; set; }
        [ForeignKey("FillStation")]
        public int FillStationId { get; set; }
        public virtual FillStation FillStation { get; set; }
        [ForeignKey("TimeBreak")]
        public int TimeBreakId { get; set; }
        public virtual TimeBreak TimeBreak { get; set; }
    }
}