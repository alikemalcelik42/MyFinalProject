using Business.Abstract;
using Business.Constants.Messages;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        [ValidationAspect(typeof(ProductValidator))]
        public IResult Add(Product product)
        {
            _productDal.Add(product);
            return new SuccessResult(Messages.ProductAdded);
        }

        public IResult Delete(Product product)
        {
            _productDal.Delete(product);
            return new SuccessResult(Messages.ProductDeleted);
        }

        public IDataResult<List<Product>> GetAll()
        {
            if (DateTime.Now.Hour == 20)
                return new ErrorDataResult<List<Product>>(Messages.MaintantenceTime);
            
            var result = _productDal.GetAll();
            return new SuccessDataResult<List<Product>>(result, Messages.ProductsListed);
        }

        public IDataResult<List<Product>> GetAllByCategoryId(int categoryId)
        {
            var result = _productDal.GetAll(p => p.CategoryId == categoryId);
            return new SuccessDataResult<List<Product>>(result, Messages.ProductsListed);
        }

        public IDataResult<List<Product>> GetAllByUnitPrice(decimal minPrice, decimal maxPrice)
        {
            var result = _productDal.GetAll(p => p.UnitPrice >= minPrice && p.UnitPrice <= maxPrice);
            return new SuccessDataResult<List<Product>>(result, Messages.ProductsListed);
        }

        public IDataResult<Product> GetById(int id)
        {
            var result = _productDal.Get(p => p.ProductId == id);
            return new SuccessDataResult<Product>(result, Messages.ProductsListed);
        }

        public IDataResult<List<ProductDetailDto>> GetProductDetails()
        {
            var result = _productDal.GetProductDetails();
            return new SuccessDataResult<List<ProductDetailDto>>(result, Messages.ProductsListed);
        }

        public IResult Update(Product product)
        {
            _productDal.Update(product);
            return new SuccessResult(Messages.ProductUpdated);
        }
    }
}
