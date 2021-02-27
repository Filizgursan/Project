using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    //İş katmanında kullanıcağımız servis operasyonlarımız
    public interface IProductService
    {
        List<Product> GetAll();
    }
}
