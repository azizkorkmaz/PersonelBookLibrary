﻿using PersonalBookLibrary.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalBookLibrary.DataAccess.Concrete.EntityFramework.Mapping
{
    public class RoleMap : EntityTypeConfiguration<Role>
    {
        public RoleMap()
        {
            ToTable(@"Roles", @"dbo");
            HasKey(x => x.RoleId);

            Property(x => x.RoleId).HasColumnName("RoleId");
            Property(x => x.RoleName).HasColumnName("RoleName");
            Property(x => x.InsertUser).HasColumnName("InsertUser");
            Property(x => x.InsertDate).HasColumnName("InsertDate");
            Property(x => x.UpdateUser).HasColumnName("UpdateUser");
            Property(x => x.UpdateDate).HasColumnName("UpdateDate");
            Property(x => x.LastUpdated).HasColumnName("LastUpdated");
            Property(x => x.Status).HasColumnName("Status");
        }
    }
}
