using FluentValidation;
using PersonalBookLibrary.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalBookLibrary.Business.ValidationRules.FluentValidation
{
    public class CategoryValidator :AbstractValidator<Category>
    {
        public CategoryValidator()
        {
            RuleFor(c => c.CategoryName).NotEmpty().WithMessage("Kategori adı boş olamaz!");
            RuleFor(c => c.CategoryName).Length(2, 50);
            RuleFor(c => c.InsertUser).NotEmpty().WithMessage("InsertUser Boş olamaz!");
        }
    }
}
