using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryProductDal : IProductDal
    {
        List<Product> _products;

        public InMemoryProductDal()
        {
            _products = new List<Product>()
            {
                new Product() { ProductId = 1, CategoryId = 1, ProductName = "Computer", UnitPrice = 6000, UnitsInStock = 400 },
                new Product() { ProductId = 2, CategoryId = 1, ProductName = "Phone", UnitPrice = 8000, UnitsInStock = 900 },
                new Product() { ProductId = 3, CategoryId = 2, ProductName = "Television", UnitPrice = 15000, UnitsInStock = 200 }
            }; 
        }

        public void Add(Product entity)
        {
            _products.Add(entity);
        }

        public void Delete(Product entity)
        {
            Product deleteProduct = _products.SingleOrDefault(p => p.ProductId == entity.ProductId);
            _products.Remove(deleteProduct);
        }

        public Product Get(Expression<Func<Product, bool>> filter = null)
        {
            return _products[0];
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            return _products;
        }

        public void Update(Product entity)
        {
            Product updateProduct = _products.SingleOrDefault(p => p.ProductId == entity.ProductId);

            updateProduct.CategoryId = entity.CategoryId;
            updateProduct.ProductName = entity.ProductName;
            updateProduct.UnitsInStock = entity.UnitsInStock;
            updateProduct.UnitPrice = entity.UnitPrice;
        }
    }
}
