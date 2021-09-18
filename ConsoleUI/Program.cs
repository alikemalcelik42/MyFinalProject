using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
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
            ProductManager productManager = new ProductManager(new EfProductDal());

            List<Product> products = productManager.GetAllByUnitPrice(50, 100);

            foreach(Product _product in products)
            {
                Console.WriteLine($"ProductId = {_product.ProductId}");
                Console.WriteLine($"CategoryId = {_product.CategoryId}");
                Console.WriteLine($"ProductName = {_product.ProductName}");
                Console.WriteLine($"UnitsInStock = {_product.UnitsInStock}");
                Console.WriteLine($"UnitPrice = {_product.UnitPrice}");
                Console.WriteLine();
            }
        }
    }
}
