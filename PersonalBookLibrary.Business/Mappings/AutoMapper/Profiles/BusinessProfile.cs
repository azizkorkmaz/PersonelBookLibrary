using AutoMapper;
using PersonalBookLibrary.Entities.ComplexTypes;
using PersonalBookLibrary.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalBookLibrary.Business.Mappings.AutoMapper.Profiles
{
    public class BusinessProfile:Profile
    {
        /*profile yazmamızın nedeni çok mapping olan sistemlerde her seferinde 
         * creatmap yapıp performans kaybını yaşamamak için bu modelde çalışmak daha doğru.*/
        public BusinessProfile()
        {
            CreateMap<Category, Category>();
            CreateMap<User, User>();
            CreateMap<UserRole, UserRole>();
            CreateMap<Role, Role>();
            CreateMap<Book, Book>();
            CreateMap<BookDetail, BookDetail>();
            CreateMap<UserRoleDetail, UserRoleDetail>();
            CreateMap<UserRolesList, UserRolesList>();
            CreateMap<ReadBook, ReadBook>();
            CreateMap<LentBook, LentBook>();
            CreateMap<LentBookDetail, LentBookDetail>();
        }
    }
}
