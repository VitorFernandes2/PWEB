﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ERecarga.DAL
{
    public partial class TimeBreak
    {

        public int TimeBreakId { get; set; }
        [Required]
        [DataType(DataType.Time)]
        public DateTime Begin { get; set; }
        [Required]
        [DataType(DataType.Time)]
        public DateTime End { get; set; }

    }
}