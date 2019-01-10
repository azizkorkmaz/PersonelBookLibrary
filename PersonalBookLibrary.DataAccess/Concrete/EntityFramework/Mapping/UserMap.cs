using PersonalBookLibrary.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalBookLibrary.DataAccess.Concrete.EntityFramework.Mapping
{
    public class UserMap:EntityTypeConfiguration<User>
    {
        public UserMap()
        {
            ToTable(@"Users", @"dbo");
            HasKey(x => x.UserId);

            Property(x => x.UserId).HasColumnName("UserId");
            Property(x => x.UserName).HasColumnName("UserName");
            Property(x => x.FirstName).HasColumnName("FirstName");
            Property(x => x.LastName).HasColumnName("LastName");
            Property(x => x.Email).HasColumnName("Email");
            Property(x => x.Password).HasColumnName("Password");
            Property(x => x.InsertUser).HasColumnName("InsertUser");
            Property(x => x.InsertDate).HasColumnName("InsertDate");
            Property(x => x.UpdateUser).HasColumnName("UpdateUser");
            Property(x => x.UpdateDate).HasColumnName("UpdateDate");
            Property(x => x.LastUpdated).HasColumnName("LastUpdated");
            Property(x => x.Status).HasColumnName("Status");
        }
    }
}
