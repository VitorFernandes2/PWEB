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
    public class StationViewModel
    {

        [Required]
        [Display(Name = "ID do proprietário")]
        public string OwnerId { get; set; }

        [Required]
        [Display(Name = "ID da região")]
        public int RegionId { get; set; }
        public SelectList Regions;

        [Required]
        public string Name { get; set; }

        public StationViewModel(ApplicationDbContext db)
        {
            Regions = ListRegions.createListItems(db);
        }

        public StationViewModel()
        {

        }

    }
}