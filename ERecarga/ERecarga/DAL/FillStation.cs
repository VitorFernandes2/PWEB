using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERecarga.DAL
{
    public partial class FillStation
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Type { get; set; }
        public bool Open { get; set; }
        public Station Station { get; set; }

    }
}