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

            var result = productManager.GetAll();

            if (result.Success == true)
            {
                foreach (var product in result.Data)
                {
                    Console.WriteLine($"{product.ProductName}");
                }
            }
            Console.WriteLine(result.Message);
        }
    }
}
