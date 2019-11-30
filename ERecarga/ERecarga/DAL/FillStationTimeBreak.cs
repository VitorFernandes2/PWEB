using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERecarga.DAL
{
    public partial class FillStationTimeBreak
    {

        public int Id { get; set; }
        public FillStation FillStation { get; set; }
        public TimeBreak TimeBreak { get; set; }
    }
}