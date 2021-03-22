using Business.Abstract;
using Business.CCS;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
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

        [ValidationAspect(typeof(ProductValidator))] //productı ve validatoru bulup validate yapıcak.
        public IResult Add(Product product)
        {

            if(CheckIfProductCountOfCategoryCorrect(product.CategoryId).Success)
            {
                if(CheckIfProductNameExists(product.ProductName).Success)
                {
                    // business code;
                    _productDal.Add(product);
                    //Bunu yapabilmek için const eklemek gerekir;
                    return new SuccessResult(Messages.ProductAdded);
                    //validation code ile business code farklıdır. İş kurallarına dahil etmek içimn yapısal olarak kontrol edip karar vermektir.
                }
            }
            return new ErrorResult();

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

        [ValidationAspect(typeof(ProductValidator))]
        public IResult Update(Product product)
        {
            //??? Bir kategoride en fazla 10 ürün olabilir???
            var result = _productDal.GetAll(p => p.CategoryId == product.CategoryId).Count;
            if (result >= 10)
            {
                return new ErrorResult(Messages.ProductCountOfCategoryError);
            }

            // business code;
            _productDal.Add(product);
            //Bunu yapabilmek için const eklemek gerekir;
            return new SuccessResult(Messages.ProductAdded);
            //validation code ile business code farklıdır. İş kurallarına dahil etmek içimn yapısal olarak kontrol edip karar vermektir.
        }
        private IResult CheckIfProductCountOfCategoryCorrect(int categoryId)
        {
            //select count(*) from products where categoryId = 1
            var result = _productDal.GetAll(p => p.CategoryId == categoryId).Count;
            if (result >= 10)
            {
                return new ErrorResult(Messages.ProductCountOfCategoryError);
            }
            return new SuccessResult();

        }
        //Aynı isimde ürün eklenemez?
        private IResult CheckIfProductNameExists (string ProductName)
        {
            var result = _productDal.GetAll(p => p.ProductName == ProductName).Any();
            if (result)
            {
                return new ErrorResult(Messages.ProductNameAlreadyExists);
            }
            return new SuccessResult();
        }
    }
}
