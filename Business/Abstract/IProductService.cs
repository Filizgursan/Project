using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    //İş katmanında kullanıcağımız servis operasyonlarımız
    public interface IProductService
    {
        //Eskiden sadece product döndürüuordu artık, message ve succes değeride döndürecek IDAtaResult sonucunda.
        IDataResult<List<Product>> GetAll();
        IDataResult<List<Product>> GetAllByCategoryId(int id);
        IDataResult<List<Product>> GetByUnitPrice(decimal min, decimal max);
        IDataResult<List<ProductDetailDto>> GetProductDetails();
        IDataResult<Product> GetById(int productId);
        // Tek bir ürün döndürür. Product
        //burada data yok void var
        IResult Add(Product product);
    }
}
