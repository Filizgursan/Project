using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using Entities.DTOs;
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

        public IResult Add(Product product)
        {
            if (product.ProductName.Length <2)
            {
                return new ErrorResult(Messages.ProductNameInvalid);
            }
            // business code;
            _productDal.Add(product);
            //Bunu yapabilmek için const eklemek gerekir;
            return new SuccessResult(Messages.ProductAdded);
        }

        public IDataResult<List<Product>> GetAll()
        {
            //İş kodlarını yazıyoruz.(if-else vs..)
            //BİR İŞ SINIFI BAŞKA BİR İŞ SINIFINI NEWLEMEZ*****
            //return _productDal.GetAll(p => p.CategoryId ==2);
            if(DateTime.Now.Hour == 23)
            {
                // MaintenanceTime bakım zamanı
                return new ErrorDataResult<List<Product>>(Messages.MaintenanceTime);
            }
            //Zaten 2 parametre döndürüyor.
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(), Messages.ProductsListed);

            
        }

        public IDataResult<List<Product>> GetAllByCategoryId(int id)
        {
            // ÖZetle SuccessDataResult içinde "<List<Product>" var ve const'a bunu gönderiyoruz.
            return new SuccessDataResult<List<Product>>( _productDal.GetAll(p => p.CategoryId == id));
        }

        public IDataResult<Product> GetById(int productId)
        {
            return new SuccessDataResult<Product>(_productDal.Get(p => p.ProductId == productId));
        }

        public IDataResult<List<Product>> GetByUnitPrice(decimal min, decimal max)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(p => p.UnitPrice >= min && p.UnitPrice <= max));
        }

        public IDataResult<List<ProductDetailDto>> GetProductDetails()
        {
            return new SuccessDataResult<List<ProductDetailDto>>(_productDal.GetProductDetails());
        }
    }
}
