using PersonalBookLibrary.Business.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PersonalBookLibrary.Entities.Concrete;
using PersonalBookLibrary.DataAccess.Abstract;
using AutoMapper;
using PersonalBookLibrary.Core.Aspects.Postsharp.VlidationAspects;
using PersonalBookLibrary.Business.ValidationRules.FluentValidation;

namespace PersonalBookLibrary.Business.Concrete.Managers
{
    public class RoleManager : IRoleService
    {
        private IRoleDal _roleDal;
        private IMapper _mapper;

        public RoleManager(IRoleDal roleDal, IMapper mapper)
        {
            _roleDal = roleDal;
            _mapper = mapper;
        }

        [FluentValidationAspect(typeof(RoleValidator))]
        public Role Add(Role role)
        {
            var rolAdd = new Role();

            if (role != null)
            {
                role.InsertUser = "Aziz";//burayı cookiden çek
                role.InsertDate = DateTime.Now.ToLocalTime();

                rolAdd = _mapper.Map<Role, Role>(_roleDal.Add(role));

                return rolAdd;
            }

            return rolAdd;
        }
        
        [FluentValidationAspect(typeof(RoleValidator))]
        public List<Role> GetAll()
        {
            var roleGetAll = _mapper.Map<List<Role>, List<Role>>(_roleDal.GetList());
            return roleGetAll;
        }

        [FluentValidationAspect(typeof(RoleValidator))]
        public Role GetById(int id)
        {
            var roleById = _mapper.Map<Role, Role>(_roleDal.Get(r => r.RoleId == id));
            return roleById;
        }

        [FluentValidationAspect(typeof(RoleValidator))]
        public Role Update(Role role)
        {
            var roleUpdate = new Role();

            if (role != null)
            {
                role.UpdateDate = DateTime.Now.ToLocalTime();
                role.UpdateUser = "Aziz";//burayı cookiden çek
                role.LastUpdated = true;

                roleUpdate = _mapper.Map<Role, Role>(_roleDal.Update(role));

                return roleUpdate;
            }

            return roleUpdate;
        }

        [FluentValidationAspect(typeof(RoleValidator))]
        public Role LooseDelete(Role role)
        {
            role.Status = false;
            var roleLooseDelete = _mapper.Map<Role, Role>(_roleDal.LooseDelete(role));
            return roleLooseDelete;
        }

        [FluentValidationAspect(typeof(RoleValidator))]
        public void HardDelete(Role role)
        {
            _roleDal.HardDelete(role);
        }
    }
}
