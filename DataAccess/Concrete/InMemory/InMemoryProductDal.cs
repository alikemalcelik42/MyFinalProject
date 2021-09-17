using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public void Add(Product product)
        {
            _products.Add(product);
        }

        public void Delete(Product product)
        {
            Product deleteProduct = _products.SingleOrDefault(p => p.ProductId == product.ProductId);
            _products.Remove(deleteProduct);
        }

        public List<Product> GetAll()
        {
            return _products;
        }

        public void Update(Product product)
        {
            Product updateProduct = _products.SingleOrDefault(p => p.ProductId == product.ProductId);

            updateProduct.CategoryId = product.CategoryId;
            updateProduct.ProductName = product.ProductName;
            updateProduct.UnitsInStock = product.UnitsInStock;
            updateProduct.UnitPrice = product.UnitPrice;
        }
    }
}
