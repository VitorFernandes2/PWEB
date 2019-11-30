using System;
using System.Collections.Generic;
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
        public DateTime Workhour { get; set; }

    }
}