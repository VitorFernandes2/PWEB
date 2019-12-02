using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
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
        [ForeignKey("Station")]
        public int StationId { get; set; }
        public virtual Station Station { get; set; }

    }
}