using PersonalBookLibrary.Business.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PersonalBookLibrary.Entities.Concrete;
using PersonalBookLibrary.DataAccess.Abstract;
using AutoMapper;
using PersonalBookLibrary.Entities.ComplexTypes;
using PersonalBookLibrary.Core.Aspects.Postsharp.TransactionAspects;
using PersonalBookLibrary.Core.Aspects.Postsharp.VlidationAspects;
using PersonalBookLibrary.Business.ValidationRules.FluentValidation;
using System.Web;
using PersonalBookLibrary.Core.CrossCuttingConcerns.Security;

namespace PersonalBookLibrary.Business.Concrete.Managers
{
    public class UserManager : IUserService
    {
        private IUserDal _userDal;
        private IUserRoleDal _userRoleDal;
        private readonly IMapper _mapper;

        public UserManager(IUserDal userDal, IMapper mapper, IUserRoleDal userRoleDal)
        {
            _userDal = userDal;
            _userRoleDal = userRoleDal;
            _mapper = mapper;
        }

        [TransactionScopeAspect]
        [FluentValidationAspect(typeof(UserValidator))]
        [FluentValidationAspect(typeof(UserRoleValidator))]
        public User Add(User user, List<int> roleIds)
        {
            var userRole = new UserRole();
            var userAdd = new User();

            user.InsertUser = (HttpContext.Current.User.Identity as Identity).UserName;
            user.InsertDate = DateTime.Now.ToLocalTime();
            user.Status = true;

            var userCheck = _mapper.Map<List<User>, List<User>>
                (_userDal.GetList(u => u.UserName == user.UserName))
                .Select(u => u.UserName).ToList();

            if (userCheck.Count <= 0)
            {
                userAdd = _mapper.Map<User, User>(_userDal.Add(user));

                foreach (var roleId in roleIds)
                {
                    userRole.InsertDate = DateTime.Now.ToLocalTime();
                    userRole.InsertUser = (HttpContext.Current.User.Identity as Identity).UserName;
                    userRole.RoleID = roleId;
                    userRole.UserID = user.UserId;
                    userRole.Status = true;

                    _userRoleDal.Add(userRole);
                }
            }

            return userAdd;
        }

        public List<User> GetAll()
        {
            var userGetAll = _mapper.Map<List<User>>(_userDal.GetList());
            return userGetAll;
        }

        public User GetById(int id)
        {
            var userGetById = _mapper.Map<User, User>(_userDal.Get(u => u.UserId == id));
            return userGetById;
        }

        public User GetByUserNameAndPassword(string userName, string password)
        {
            var userNameAndPassword = _mapper.Map<User, User>(
                _userDal.Get(u => u.UserName == userName & u.Password == password));
            return userNameAndPassword;
        }

        public List<UserRoleDetail> GetUserRoles(User user)
        {
            var userRoleDetail = _mapper.Map<List<UserRoleDetail>, List<UserRoleDetail>>(_userDal.GetUserRoles(user));

            return userRoleDetail;
        }

        [TransactionScopeAspect]
        [FluentValidationAspect(typeof(UserValidator))]
        [FluentValidationAspect(typeof(UserRoleValidator))]
        public User Update(User user, List<int> roleIds)
        {
            var userRole = new UserRole();

            user.UpdateDate = DateTime.Now.ToLocalTime();
            user.LastUpdated = true;
            user.UpdateUser = (HttpContext.Current.User.Identity as Identity).UserName;

            var roles = _userRoleDal.GetList().Where(u => u.UserID == user.UserId).Select(u => u.UserRolesId).ToList();

            var userUpdate = _mapper.Map<User, User>(_userDal.Update(user));

            foreach (var role in roles)
            {
                var userRol = _userRoleDal.Get(u => u.UserRolesId == role);

                _userRoleDal.HardDelete(userRol);
            }

            foreach (var role in roleIds)
            {
                userRole.InsertUser = (HttpContext.Current.User.Identity as Identity).UserName;
                userRole.InsertDate = DateTime.Now.ToLocalTime();
                userRole.RoleID = role;
                userRole.UserID = user.UserId;
                userRole.Status = user.Status == true ? true : false;

                _userRoleDal.Add(userRole);
            }
            return userUpdate;
        }

        [TransactionScopeAspect]
        [FluentValidationAspect(typeof(UserValidator))]
        [FluentValidationAspect(typeof(UserRoleValidator))]
        public User LooseDelete(User user)
        {
            var userRole = new UserRole();

            user.UpdateDate = DateTime.Now.ToLocalTime();
            user.LastUpdated = true;
            user.UpdateUser = (HttpContext.Current.User.Identity as Identity).UserName;
            user.Status = false;

            var roles = _userRoleDal.GetList().Where(u => u.UserID == user.UserId).Select(u => u.UserRolesId).ToList();

            foreach (var role in roles)
            {
                userRole = _userRoleDal.Get(ur => ur.UserRolesId == role);

                userRole.UpdateUser = "Aziz";//burayı cookiden çek
                userRole.UpdateDate = DateTime.Now.ToLocalTime();
                userRole.LastUpdated = true;
                userRole.Status = user.Status == true ? true : false;

                _userRoleDal.LooseDelete(userRole);
            }

            var userDelete = _mapper.Map<User, User>(_userDal.LooseDelete(user));

            return userDelete;
        }

        [TransactionScopeAspect]
        [FluentValidationAspect(typeof(UserValidator))]
        [FluentValidationAspect(typeof(UserRoleValidator))]
        public void HardDelete(User user)
        {
            _userDal.HardDelete(user);
        }
    }
}
