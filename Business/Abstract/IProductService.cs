using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IProductService
    {
        List<Product> GeTAll();
        List<Product> GetByCategory(int categoryId);
        List<Product> GetBySupplier(int supplierId);
        Product GetById(int productId);
        


        
    }
}
