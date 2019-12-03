﻿using ERecarga.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ERecarga.DAL
{
    public partial class Station
    {

        public int Id { get; set; }
        [ForeignKey("ApplicationUser")]
        public string OwnerId { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
        [ForeignKey("Region")]
        public int RegionId { get; set; }
        public virtual Region Region { get; set; }
        public string Name { get; set; }

    }
}