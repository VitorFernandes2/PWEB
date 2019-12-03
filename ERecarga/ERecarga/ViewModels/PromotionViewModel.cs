using ERecarga.App_Code;
using ERecarga.DAL;
using ERecarga.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ERecarga.ViewModels
{
    public class PromotionViewModel
    {

        public int Id { get; set; }

        [Required]
        public int FillStationId { get; set; }
        public SelectList FillStationList;

        public virtual FillStation FillStation { get; set; }

        public double Price { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Inicio da Promoção")]
        [Required(ErrorMessage = "Insira uma data correta")]
        public DateTime PromotionStart { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Fim da Promoção")]
        [Required(ErrorMessage = "Insira uma data correta")]
        public DateTime PromotionEnd { get; set; }

        public PromotionViewModel(ApplicationDbContext db)
        {
            FillStationList = ListFillStation.createListItems(db);
        }
    }
}