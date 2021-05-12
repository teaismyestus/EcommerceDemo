using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        private IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;

        }

      
        public List<Product> GeTAll()
        {
           return _productDal.GetList();
        }

        public List<Product> GetByCategory(int categoryId)
        {
            return _productDal.GetList(p => p.CategoryID == categoryId);
        }

       

        Product IProductService.GetById(int productId)
        {
            return _productDal.Get(p => p.ProductID == productId);
        }

        List<Product> IProductService.GetBySupplier(int supplierId)
        {
            return _productDal.GetList(p => p.SupplierID == supplierId);
        }
    }
}
