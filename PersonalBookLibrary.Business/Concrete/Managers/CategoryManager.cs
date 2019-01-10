using PersonalBookLibrary.Business.Abstract;
using System.Collections.Generic;
using PersonalBookLibrary.Entities.Concrete;
using PersonalBookLibrary.DataAccess.Abstract;
using PersonalBookLibrary.Business.ValidationRules.FluentValidation;
using System.Transactions;
using PersonalBookLibrary.Core.Aspects.Postsharp.VlidationAspects;
using PersonalBookLibrary.Core.Aspects.Postsharp.TransactionAspects;
using PersonalBookLibrary.Core.Aspects.Postsharp.CacheAspects;
using PersonalBookLibrary.Core.CrossCuttingConcerns.Caching.Microsoft;
using PersonalBookLibrary.Core.CrossCuttingConcerns.Logging.Log4Net.Loggers;
using PersonalBookLibrary.Core.Aspects.Postsharp.LogAspects;
using PersonalBookLibrary.Core.Aspects.Postsharp.PerformanceAspects;
using System.Threading;
using PersonalBookLibrary.Core.Aspects.Postsharp.AuthorizationAspects;
using AutoMapper;
using PersonalBookLibrary.Core.Utilities.Mappings;
using System;

namespace PersonalBookLibrary.Business.Concrete.Managers
{
    public class CategoryManager : ICategoryService
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
        public Category Add(Category category)
        {
            /* Burada validate yapmamız doğru değil Solid e uygun değil. Bu kodu aspect şeklinde yazacağız.*/
            //ValidatorTool.FluentValidate(new CategoryValidator(), category);
            return _categoryDal.Add(category);
        }

        [CacheAspect(typeof(MemoryCacheManager))]
        [PerformanceCounterAspect(2)]
        //[SecuredOperationAspect(Roles="Admin,Editor,Student")]
        public List<Category> GetAll()
        {
            //Thread.Sleep(3000);
            //return _categoryDal.GetList();

            /*entityframework un eski sürümlerinde serileştirme işlemi yapamadığı için yazdık.*/

            /*Aşağıdaki kod öneğini core katmanında yazdığımız AutoMapperHelper ile mapliyoruz.*/
            //var categories = AutoMapperHelper.MapToSameTypeList(_categoryDal.GetList());

            /*Burada ki kod örneğinde ise business katmanında ninject yardımı ile yazdığımız mappermodule kullanıyoruz. daha büyük ölçekli perojeler için.*/
            var categories = _mapper.Map<List<Category>>(_categoryDal.GetList());
            return categories;
        }


        public Category GetById(int id)
        {
            return _categoryDal.Get(c => c.CategoryId == id);
        }

        [FluentValidationAspect(typeof(CategoryValidator))]
        public Category Update(Category category)
        {
            return _categoryDal.Update(category);
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

        public void Delete(Category category)
        {
            _categoryDal.Delete(category);
        }
    }
}
