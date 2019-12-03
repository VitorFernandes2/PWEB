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
        public int RegionId { get; set; }

        [Required(ErrorMessage = "Insira o nome da estação!")]
        [Display(Name = "Nome da estação")]
        public string Name { get; set; }

    }
}