﻿using PersonalBookLibrary.Entities.ComplexType;
using PersonalBookLibrary.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalBookLibrary.Business.Abstract
{
    public interface IUserService
    {
        List<User> GetAll();

        User GetById(int id);

        User Add(User user);

        User Update(User user);

        void Delete(User user);

        User GetByUserNameAndPassword(string userName, string password);

        List<UserRoleItem> GetUserRoles(User user);
    }
}