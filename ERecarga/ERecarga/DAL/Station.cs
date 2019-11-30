using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ERecarga.DAL
{
    public class Station
    {

        public int Id { get; set; }
        public int RegionId { get; set; }
        public int DiscountId { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        [Required]
        [DataType(DataType.Time)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:H:mm}")]
        public DateTime WorkhourBegin { get; set; }
        [Required]
        [DataType(DataType.Time)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:H:mm}")]
        public DateTime WorkhourEnd { get; set; }
    }
}