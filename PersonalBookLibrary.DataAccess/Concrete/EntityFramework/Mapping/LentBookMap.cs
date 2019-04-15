using PersonalBookLibrary.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalBookLibrary.DataAccess.Concrete.EntityFramework.Mapping
{
    public class LentBookMap : EntityTypeConfiguration<LentBook>
    {
        public LentBookMap()
        {
            ToTable(@"LentBooks", @"dbo");
            HasKey(x => x.LentBookId);

            Property(x => x.LentBookId).HasColumnName("LentBookId");
            Property(x => x.BookID).HasColumnName("BookID");
            Property(x => x.BorrowPersonName).HasColumnName("BorrowPersonName");
            Property(x => x.BorrowPersonLastName).HasColumnName("BorrowPersonLastName");
            Property(x => x.GivenUserName).HasColumnName("GivenUserName");
            Property(x => x.GivenDate).HasColumnName("GivenDate");
            Property(x => x.UndoDate).HasColumnName("UndoDate");
            Property(x => x.InsertUser).HasColumnName("InsertUser");
            Property(x => x.InsertDate).HasColumnName("InsertDate");
            Property(x => x.UpdateUser).HasColumnName("UpdateUser");
            Property(x => x.UpdateDate).HasColumnName("UpdateDate");
            Property(x => x.LastUpdated).HasColumnName("LastUpdated");
            Property(x => x.Status).HasColumnName("Status");
        }
    }
}
