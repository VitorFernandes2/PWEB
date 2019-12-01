using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ERecarga.DAL
{
    [MetadataType(typeof(TimeBreakMetadata))]
    public partial class TimeBreak { };

    public class TimeBreakMetadata
    {
        [Required(ErrorMessage = "Insira a hora de inicio")]
        [Display(Name = "Hora de inicio")]
        public DateTime Begin { get; set; }
        [Required(ErrorMessage = "Insira a hora de fim")]
        [Display(Name = "Hora de fim")]
        public DateTime End { get; set; }

    }
}