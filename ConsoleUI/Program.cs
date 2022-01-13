using Business.Concrete;
using Core.CrossCuttingConcerns.Caching.Redis;
using DataAccess.Concrete.EntityFramework;
using System;

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