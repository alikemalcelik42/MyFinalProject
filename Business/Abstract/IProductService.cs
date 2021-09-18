using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IProductService
    {
        List<Product> GetAll();
        List<Product> GetAllByCategoryId(int categoryId);
        List<Product> GetAllByUnitPrice(decimal minPrice, decimal maxPrice);
        void Add(Product product);
        void Update(Product product);
        void Delete(Product product);
    }
}
