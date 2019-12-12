using ERecarga.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ERecarga.DAL
{
    public partial class BankInfo
    {
        public int Id { get; set; }
        public int NIB { get; set; }
        public double Quant { get; set; }
        [ForeignKey("ApplicationUser")]
        public string UserId { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}