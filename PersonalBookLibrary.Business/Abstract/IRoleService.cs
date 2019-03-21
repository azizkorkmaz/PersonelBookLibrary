using PersonalBookLibrary.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalBookLibrary.Business.Abstract
{
    public interface IRoleService
    {
        List<Role> GetAll();

        Role GetById(int id);

        Role Add(Role role);

        Role Update(Role role);

        Role LooseDelete(Role role);

        void HardDelete(Role role);
    }
}
