using PersonalBookLibrary.DataAccess.Concrete.EntityFramework.Mapping;
using PersonalBookLibrary.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalBookLibrary.DataAccess.Concrete.EntityFramework
{
    public class PersonalBookLibraryContext:DbContext
    {
        public PersonalBookLibraryContext()
        {
            /*database müdahaleyi kısıtlıyoruz ve kodtakine göre database üzerinde 
            * oynamasını engelliyoruz*/
            Database.SetInitializer<PersonalBookLibraryContext>(null);
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Book> Books { get; set; }

        public DbSet<Role> Roles { get; set; }

        public DbSet<UserRole> UserRoles { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new UserMap());
            modelBuilder.Configurations.Add(new BookMap());
            modelBuilder.Configurations.Add(new RoleMap());
            modelBuilder.Configurations.Add(new UserRoleMap());
            modelBuilder.Configurations.Add(new CategoryMap());
        }
    }
}
