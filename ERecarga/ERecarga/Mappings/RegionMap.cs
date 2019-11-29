using ERecarga.DAL;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace ERecarga.Mappings
{
    public class RegionMap : EntityTypeConfiguration<Region>
    {

        public RegionMap()
        {

            this.Property(r => r.Name).IsRequired();

        }

    }
}