using AutoMapper;
using PersonalBookLibrary.Business.Abstract;
using PersonalBookLibrary.DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PersonalBookLibrary.Entities.Concrete;
using System.Web;
using PersonalBookLibrary.Core.CrossCuttingConcerns.Security;

namespace PersonalBookLibrary.Business.Concrete.Managers
{
    public class UserRoleManager:IUserRoleService
    {
        private IUserRoleDal _userRoleDal;
        private IMapper _mapper;

        public UserRoleManager(IUserRoleDal userRoleDal, IMapper mapper)
        {
            _userRoleDal = userRoleDal;
            _mapper = mapper;
        }

        public List<UserRole> GetAll()
        {
            var userRoleGetAll = _mapper.Map<List<UserRole>, List<UserRole>>(_userRoleDal.GetList());
            return userRoleGetAll;
        }

        public UserRole GetById(int id)
        {
            var userRoleById = _mapper.Map<UserRole, UserRole>(_userRoleDal.Get(ur => ur.RoleID == id));
            return userRoleById;
        }

        public UserRole Add(int userId, int roleId)
        {
            var userRole = new UserRole
            {
                RoleID = roleId,
                UserID = userId,
                InsertDate = DateTime.Now.ToLocalTime(),
                InsertUser = (HttpContext.Current.User.Identity as Identity).UserName,
                Status = true
            };

            var userRoleAdd = _mapper.Map<UserRole, UserRole>(_userRoleDal.Add(userRole));
            return userRoleAdd;
        }

        public UserRole Update(UserRole userRole)
        {
            userRole.LastUpdated = true;
            userRole.UpdateDate = DateTime.Now.ToLocalTime();
            userRole.UpdateUser = (HttpContext.Current.User.Identity as Identity).UserName;
            var userRoleUpdate = _mapper.Map<UserRole, UserRole>(_userRoleDal.Update(userRole));
            return userRoleUpdate;
        }

        public UserRole LooseDelete(UserRole userRole)
        {
            userRole.Status = false;

            var userRoleDelete = _mapper.Map<UserRole, UserRole>(_userRoleDal.LooseDelete(userRole));
            return userRoleDelete;
        }

        public void HardDelete(UserRole userRole)
        {
            _userRoleDal.HardDelete(userRole);
        }
    }
}
