using FluentValidation;
using PersonalBookLibrary.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalBookLibrary.Business.ValidationRules.FluentValidation
{
    class UserRoleValidator : AbstractValidator<UserRole>
    {
        public UserRoleValidator()
        {
            RuleFor(ur => ur.RoleID).NotNull().WithMessage("RolID boş olamaz!");
            RuleFor(ur => ur.UserID).NotNull().WithMessage("UserID boş olamaz!");
        }
    }
}
