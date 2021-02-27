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
            return _productDal.GetAll();
        }
    }
}
