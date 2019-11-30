using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ERecarga.DAL
{

    [MetadataType(typeof(RegionMetada))]
    public partial class Region { };

    public class RegionMetada
    {

        [Display(Name = "Nome")]
        [Required(ErrorMessage = "Insira o nome da região")]
        [StringLength(126, MinimumLength = 2,
            ErrorMessage = "O {0} deve de ter entre 1 a 126 caracteres")]
        public string Name { get; set; }

    }
}