using Core.DataAccess;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

//Dal or Dao : Data Access Object or Layer
//Productla ilgili operasyonları gerçekleştireceğim interface diyebiliriz.
//interface değil, operasyonları public bu nedenle manuel şekilde public yapmazsak hata alabiliriz.
namespace DataAccess.Abstract
{
    public interface IProductDal:IEntityRepository<Product>
    {
        //Add ile project references yaptık cünkü entititese erişmemiş gerek. 
       
    }
}
