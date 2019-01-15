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
        public Category Add(Category category)
        {
            /* Burada validate yapmamız doğru değil Solid e uygun değil. Bu kodu aspect şeklinde yazacağız.*/
            //ValidatorTool.FluentValidate(new CategoryValidator(), category);

            var categoryAdd = _mapper.Map<Category, Category>(_categoryDal.Add(category));
            return categoryAdd;
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
            var category = _mapper.Map<Category, Category>(_categoryDal.Get(c => c.CategoryId == id));
            return category;
        }

        [FluentValidationAspect(typeof(CategoryValidator))]
        public Category Update(Category category)
        {
            var categoryUpdate = _mapper.Map<Category, Category>(_categoryDal.Update(category));
            /*Burada LastUpdate ,updateUser ve UpdateDate propertyleri ayarla.*/
            return categoryUpdate;
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

        public Category Delete(Category category)
        {
            var categoryDelete = _mapper.Map<Category, Category>(_categoryDal.Delete(category));
            categoryDelete.Status = false;
            return categoryDelete;
        }
    }
}
