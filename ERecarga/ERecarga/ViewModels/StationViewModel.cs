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
        public string OwnerId { get; set; }

        [Required]
        public int RegionId { get; set; }
        public SelectList Regions;

        [Required]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.Time)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:H:mm}")]
        public DateTime WorkhourBegin { get; set; }

        [Required]
        [DataType(DataType.Time)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:H:mm}")]
        public DateTime WorkhourEnd { get; set; }

        public StationViewModel(ApplicationDbContext db)
        {
            Regions = ListRegions.createListItems(db);
        }

        public StationViewModel()
        {

        }

    }
}