using ERecarga.App_Code;
using ERecarga.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ERecarga.ViewModels
{
    public class FillStationViewModel
    {

        [Display(Name = "Nome")]
        [Required(ErrorMessage = "Insira o nome do posto")]
        public string Name { get; set; }

        [Display(Name = "Preço")]
        [Required(ErrorMessage = "Insira o preço do posto")]
        public double Price { get; set; }

        [Display(Name = "Tipo de posto")]
        [Required(ErrorMessage = "Insira o tipo da posto")]
        public string Type { get; set; }

        public bool Open { get; set; }

        [Display(Name = "Estação do posto")]
        [Required(ErrorMessage = "Insira a estação a que este posto pertence")]
        public int StationId { get; set; }
        public SelectList Stations;

        public FillStationViewModel(ApplicationDbContext db)
        {
            Stations = ListStations.createListItems(db);
        }

        public FillStationViewModel()
        {

        }

    }
}