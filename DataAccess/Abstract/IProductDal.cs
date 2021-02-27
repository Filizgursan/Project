using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

//Dal or Dao : Data Access Object or Layer
//Productla ilgili operasyonları gerçekleştireceğim interface diyebiliriz.
//interface değil, operasyonları public bu nedenle manul şekilde public yapmazsak hata alabiliriz.
namespace DataAccess.Abstract
{
    public interface IProductDal
    {
        //Add ile project references yaptık cünkü entititese erişmemiş gerek. 
        List<Product> GetAll();
        void Add(Product product);
        void Update(Product product);
        void Delete(Product product);
        
        //Ürünleri kategoriye göre filtrele
        List<Product> GetAllByCategory(int categoryId);

    }
}
