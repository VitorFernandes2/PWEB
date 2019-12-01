using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ERecarga.DAL
{

    [MetadataType(typeof(StationMetadata))]
    public partial class Station { };

    public class StationMetadata
    {

        [Required(ErrorMessage = "Insira a região!")]
        [Display(Name = "Região")]
        public Region Region { get; set; }

        [Required(ErrorMessage = "Insira o nome da estação!")]
        [Display(Name = "Nome da estação")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Insira a Hota de inicio de trabalhos!")]
        [Display(Name = "Hora de inicio de trabalhos")]
        public DateTime WorkhourBegin { get; set; }

        [Required(ErrorMessage = "Insira a hora de fim de trabalhos!")]
        [Display(Name = "Hora de fim de trabalhos")]
        public DateTime WorkhourEnd { get; set; }

    }
}