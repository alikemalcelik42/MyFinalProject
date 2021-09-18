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

            var productDetails = productManager.GetProductDetails();

            foreach(var productDetail in productDetails)
            {
                Console.WriteLine($"{productDetail.ProductName} / {productDetail.CategoryName}");
            }
        }
    }
}
