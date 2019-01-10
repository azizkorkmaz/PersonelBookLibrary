using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PersonalBookLibrary.DataAccess.Abstract;
using PersonalBookLibrary.Business.Concrete.Managers;
using PersonalBookLibrary.Entities.Concrete;
using FluentValidation;

namespace PersonalBookLibrary.Business.Tests
{
    [TestClass]
    public class CategoryManagerTests
    {
        [ExpectedException(typeof(ValidationException))]
        [TestMethod]
        public void Categroy_validation_check()
        {
            Mock<ICategoryDal> mock = new Mock<ICategoryDal>();
           // CategoryManager categoryManager = new CategoryManager(mock.Object);

           // categoryManager.Add(new Category());
        }
    }
}
