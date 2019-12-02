using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ERecarga.DAL
{
    public partial class Promotion
    {

        public int Id { get; set; }
        [ForeignKey("FillStation")]
        public int FillStationId { get; set; }
        public virtual FillStation FillStation { get; set; }
        public double Price { get; set; }
        [DataType(DataType.Date)]
        public DateTime PromotionStart { get; set; }
        [DataType(DataType.Date)]
        public DateTime PromotionEnd { get; set; }

    }
}