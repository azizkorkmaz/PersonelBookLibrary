using PersonalBookLibrary.Business.Abstract;
using System.Collections.Generic;
using PersonalBookLibrary.Entities.Concrete;
using PersonalBookLibrary.DataAccess.Abstract;
using PersonalBookLibrary.Business.ValidationRules.FluentValidation;
using PersonalBookLibrary.Core.Aspects.Postsharp.VlidationAspects;
using PersonalBookLibrary.Core.Aspects.Postsharp.TransactionAspects;
using PersonalBookLibrary.Core.Aspects.Postsharp.CacheAspects;
using PersonalBookLibrary.Core.CrossCuttingConcerns.Caching.Microsoft;
using PersonalBookLibrary.Core.Aspects.Postsharp.PerformanceAspects;
using AutoMapper;
using PersonalBookLibrary.Core.Aspects.Postsharp.AuthorizationAspects;
using System;

namespace PersonalBookLibrary.Business.Concrete.Managers
{
    public class CategoryManager :ICategoryService
    {
        /*burada veri erişim katmanı kulanarak işlemleri gerçekleştirecez.*/
        private ICategoryDal _categoryDal;
        private readonly IMapper _mapper;

        public CategoryManager(ICategoryDal categoryDal, IMapper mapper)
        {
            _categoryDal = categoryDal;
            _mapper = mapper;
        }
        
        [FluentValidationAspect(typeof(CategoryValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]//ekleme yapıldığında bütün cacheleri siler
        [SecuredOperationAspect(Roles = "Admin,Editor,Student")]
        public Category Add(Category category)
        {
            /* Burada validate yapmamız doğru değil Solid e uygun değil. Bu kodu aspect şeklinde yazacağız.*/
            //ValidatorTool.FluentValidate(new CategoryValidator(), category);
            category.InsertDate = DateTime.Now.ToLocalTime();
            category.InsertUser = "Aziz";//burayı cookie den çek
            category.LastUpdated = false;

            var categoryAdd = _mapper.Map<Category, Category>(_categoryDal.Add(category));
            return categoryAdd;
        }

        [CacheAspect(typeof(MemoryCacheManager))]
        [PerformanceCounterAspect(2)]
        public List<Category> GetAll()
        {
            //Thread.Sleep(3000);
            //return _categoryDal.GetList();

            /*entityframework te serileştirme işlemi yapamadığı için yazdık.*/

            /*Aşağıdaki kod öneğini core katmanında yazdığımız AutoMapperHelper ile mapliyoruz.*/
            //var categories = AutoMapperHelper.MapToSameTypeList(_categoryDal.GetList());

            /*Burada ki kod örneğinde ise business katmanında ninject yardımı ile yazdığımız mappermodule kullanıyoruz. daha büyük ölçekli perojeler için.*/
            var categories = _mapper.Map<List<Category>>(_categoryDal.GetList());
            return categories;
        }

        [FluentValidationAspect(typeof(CategoryValidator))]
        public Category GetById(int id)
        {
            var category = _mapper.Map<Category, Category>(_categoryDal.Get(c => c.CategoryId == id));
            return category;
        }

        [FluentValidationAspect(typeof(CategoryValidator))]
        [SecuredOperationAspect(Roles = "Student")]
        public Category Update(Category category)
        {
            category.LastUpdated = true;
            category.UpdateDate = DateTime.Now.ToLocalTime();
            category.UpdateUser = "Aziz";//burayı cookiden çek

            var categoryUpdate = _mapper.Map<Category, Category>(_categoryDal.Update(category));
            
            return categoryUpdate;
            //burada not authorized hatası geliyor SecuredOperationAspect ten dolayı 
        }

        [TransactionScopeAspect]
        [FluentValidationAspect(typeof(CategoryValidator))]
        public void TransactionalOperation(Category category1, Category category2)
        {
            /*Aşağıda kapattığım kodun görevini yapan core katmanınında yazdığımız TransactionScopeAspect atribute şeklinde vererek AOP yaptık.*/
            //using (TransactionScope scope = new TransactionScope())
            //{
            //    try
            //    {
            //        _categoryDal.Add(category1);
            //        _categoryDal.Update(category2);
            //        scope.Complete();
            //    }
            //    catch 
            //    {
            //        scope.Dispose();
            //    }
            //}

            _categoryDal.Add(category1);
            _categoryDal.Update(category2);
        }

        [FluentValidationAspect(typeof(CategoryValidator))]
        [SecuredOperationAspect(Roles = "Admin,Editor,Student")]
        public Category LooseDelete(Category category)
        {
            category.Status = false;

            var categoryLooseDelete = _mapper.Map<Category, Category>(_categoryDal.Update(category));
            return categoryLooseDelete;
        }

        [FluentValidationAspect(typeof(CategoryValidator))]
        [SecuredOperationAspect(Roles = "Admin,Editor,Student")]
        public void HardDelete(Category category)
        {
             _categoryDal.HardDelete(category);
        }
    }
}
