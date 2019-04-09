using PersonalBookLibrary.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalBookLibrary.DataAccess.Concrete.EntityFramework.Mapping
{
    public class ReadBookMap: EntityTypeConfiguration<ReadBook>
    {
        public ReadBookMap()
        {
            ToTable(@"ReadBooks", @"dbo");
            HasKey(x => x.ReadBookId);

            Property(x => x.ReadBookId).HasColumnName("ReadBookId");
            Property(x => x.BookName).HasColumnName("BookName");
            Property(x => x.AuthorName).HasColumnName("AuthorName");
            Property(x => x.InsertUser).HasColumnName("InsertUser");
            Property(x => x.InsertDate).HasColumnName("InsertDate");
            Property(x => x.UpdateUser).HasColumnName("UpdateUser");
            Property(x => x.UpdateDate).HasColumnName("UpdateDate");
            Property(x => x.LastUpdated).HasColumnName("LastUpdated");
            Property(x => x.Status).HasColumnName("Status");
        }
    }
}
