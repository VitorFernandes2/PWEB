using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ERecarga.DAL
{

    [MetadataType(typeof(ReservationMetadata))]
    public partial class Reservation { };

    public class ReservationMetadata
    {

        [Required]
        [Display(Name = "ID do Intervalo de Estação")]
        public int FillStationTimeBreakId { get; set; }
        [DataType(DataType.Date)]
        [Required]
        public DateTime Day { get; set; }

    }

}