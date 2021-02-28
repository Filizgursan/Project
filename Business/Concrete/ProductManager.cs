using Business.Abstract;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    //Manager iş katmanının somut sınıfıdır.
    public class ProductManager : IProductService
    {
        IProductDal _productDal;

        // product manager Iproductdal referans ver diyor.
        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public List<Product> GetAll()
        {
            //İş kodlarını yazıyoruz.(if-else vs..)
            //BİR İŞ SINIFI BAŞKA BİR İŞ SINIFINI NEWLEMEZ*****
            //return _productDal.GetAll(p => p.CategoryId ==2);
            return _productDal.GetAll();
        }

        public List<Product> GetAllByCategoryId(int id)
        {
            return _productDal.GetAll(p => p.CategoryId == id);
        }

        public List<Product> GetByUnitPrice(decimal min, decimal max)
        {
            return _productDal.GetAll(p => p.UnitPrice >= min && p.UnitPrice <= max);
        }
    }
}
