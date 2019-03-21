using FluentValidation;
using PersonalBookLibrary.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalBookLibrary.Business.ValidationRules.FluentValidation
{
    public class UserValidator: AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(u => u.Email).NotEmpty().EmailAddress().WithMessage("Email adresi boş olamaz!");
            RuleFor(u => u.FirstName).NotEmpty().WithMessage("Ad alanı boş olamaz!");
            RuleFor(u => u.LastName).NotEmpty().WithMessage("Soyad alanı boş olamaz!");
            RuleFor(u => u.UserName).Length(4, 10);
            RuleFor(u => u.Password).NotEmpty().WithMessage("Şifre alanı boş olamaz!");
        }
    }
}
