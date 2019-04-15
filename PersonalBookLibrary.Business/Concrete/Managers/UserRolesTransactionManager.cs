using PersonalBookLibrary.Business.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PersonalBookLibrary.Entities.Concrete;
using PersonalBookLibrary.DataAccess.Abstract;
using AutoMapper;
using PersonalBookLibrary.Core.Aspects.Postsharp.TransactionAspects;
using PersonalBookLibrary.Entities.ComplexTypes;
using PersonalBookLibrary.Core.Aspects.Postsharp.VlidationAspects;
using PersonalBookLibrary.Business.ValidationRules.FluentValidation;
using System.Web;
using PersonalBookLibrary.Core.CrossCuttingConcerns.Security;

namespace PersonalBookLibrary.Business.Concrete.Managers
{
    public class UserRolesTransactionManager : IUserRolesTransactionService
    {

        private readonly IUserDal _userDal;
        private readonly IUserRoleDal _userRoleDal;
        private readonly IMapper _mapper;

        public UserRolesTransactionManager(IUserDal userDal, IUserRoleDal userRoleDal, IMapper mapper)
        {
            _userDal = userDal;
            _userRoleDal = userRoleDal;
            _mapper = mapper;
        }

        [TransactionScopeAspect]
        [FluentValidationAspect(typeof(UserValidator))]
        [FluentValidationAspect(typeof(UserRoleValidator))]
        public UserRolesList AddUserRolesTransaction(User user, List<int> userRoleIds)
        {
            var userRole = new UserRole();
            var insertUser = new User();
            var insertUserRole = new UserRole();
            var userRolesAddTrns = new UserRolesList();

            try
            {
                if (user != null)
                {
                    insertUser = _userDal.Add(user);
                    if (userRoleIds != null && userRoleIds.Any() && insertUser.UserId > 0)
                    {
                        foreach (var role in userRoleIds)
                        {
                            userRole = new UserRole
                            {
                                InsertDate = DateTime.Now.ToLocalTime(),
                                InsertUser = (HttpContext.Current.User.Identity as Identity).UserName,
                                RoleID = role,
                                UserID = user.UserId,
                                Status = true
                            };

                            insertUserRole = 
                                _mapper.Map<UserRole, UserRole>(_userRoleDal.Add(userRole));

                        }
                    }

                    userRolesAddTrns = new UserRolesList
                    {
                        User = insertUser,
                        UserRole = insertUserRole
                    };
                }
                return userRolesAddTrns;
            }
            catch (Exception)
            {
                throw;
            }
        }

        [TransactionScopeAspect]
        [FluentValidationAspect(typeof(UserValidator))]
        [FluentValidationAspect(typeof(UserRoleValidator))]
        public UserRolesList UpdateUserRolesTransaction(User user, List<int> userRoleIds)
        {
            var userRole = new UserRole();
            var updateUser = new User();
            var updateUserRole = new UserRole();
            var userRolesUpdateTrns = new UserRolesList();

            try
            {
                if (user != null)
                {
                    updateUser = _userDal.Update(user);

                    if (userRoleIds != null && userRoleIds.Any())
                    {
                        foreach (var role in userRoleIds)
                        {
                            userRole = new UserRole
                            {
                                InsertDate = DateTime.Now.ToLocalTime(),
                                InsertUser = 
                                (HttpContext.Current.User.Identity as Identity).UserName,
                                RoleID = role,
                                UserID = user.UserId,
                                Status = true
                            };

                            updateUserRole = _mapper.Map<UserRole, UserRole>(_userRoleDal.Add(userRole));

                        }
                    }

                    userRolesUpdateTrns = new UserRolesList
                    {
                        User = updateUser,
                        UserRole = updateUserRole
                    };
                }
                return userRolesUpdateTrns;
            }
            catch (Exception)
            {
                throw;
            }
        }

        [TransactionScopeAspect]
        [FluentValidationAspect(typeof(UserValidator))]
        [FluentValidationAspect(typeof(UserRoleValidator))]
        public UserRolesList GetAllUserRolesTransaction()
        {
            var userRolesGetAllTrns = new UserRolesList
            {
                Users = _mapper.Map<List<User>, List<User>>(_userDal.GetList()),
                UserRoles = _mapper.Map<List<UserRole>, List<UserRole>>(_userRoleDal.GetList())
            };

            return userRolesGetAllTrns;
        }

        [TransactionScopeAspect]
        [FluentValidationAspect(typeof(UserValidator))]
        [FluentValidationAspect(typeof(UserRoleValidator))]
        public UserRolesList GetByIdUserRolesTransaction(int id)
        {
            var userRolesGetByIdTrns = new UserRolesList
            {
                User = _mapper.Map<User, User>(_userDal.Get(u => u.UserId == id)),
                UserRoleIds = _userRoleDal.GetList()
                .Where(ur => ur.UserID == id).Select(r => r.RoleID).ToList()
            };

            return userRolesGetByIdTrns;
        }


        [TransactionScopeAspect]
        [FluentValidationAspect(typeof(UserValidator))]
        [FluentValidationAspect(typeof(UserRoleValidator))]
        public UserRolesList LooseDeleteUserRolesTransaction(User user, List<int> userRoleIds)
        {
            var userRole = new UserRole();

            var userRolesDeleteTrns = new UserRolesList
            {
                User = _mapper.Map<User, User>(_userDal.LooseDelete(user)),
                UserRole = _mapper.Map<UserRole, UserRole>(_userRoleDal.LooseDelete(userRole))
            };

            return userRolesDeleteTrns;
        }


        [TransactionScopeAspect]
        [FluentValidationAspect(typeof(UserValidator))]
        [FluentValidationAspect(typeof(UserRoleValidator))]
        public void HardDeleteUserRolesTransaction(User user, List<int> userRoleIds)
        {
            //burası için detaylı bir çalışma yap
            _userDal.HardDelete(user);
            
        }
    }
}
