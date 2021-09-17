using Business.Concrete;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;
using System.Collections.Generic;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            ProductManager productManager = new ProductManager(new InMemoryProductDal());

            Product product = new Product()
            {
                ProductId = 4,
                CategoryId = 2,
                ProductName = "Tablet",
                UnitsInStock = 300,
                UnitPrice = 4000
            };

            productManager.Add(product);
            product.UnitPrice = 3000;
            productManager.Update(product);

            List<Product> products = productManager.GetAll();

            foreach(Product _product in products)
            {
                Console.WriteLine(_product.ProductId);
                Console.WriteLine(_product.CategoryId);
                Console.WriteLine(_product.ProductName);
                Console.WriteLine(_product.UnitsInStock);
                Console.WriteLine(_product.UnitPrice);
                Console.WriteLine();
            }
        }
    }
}
