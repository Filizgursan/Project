using Core.DataAccess;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    //Her nesneye bunları(Add,Update..) yazmayalım diye generic bir interface oluşturabiliriz.

    //IEntityRepository ile metodlar için tek tek nesne oluşturmamıza gerek kalmadı
    public interface ICategoryDal:IEntityRepository<Category>
    {
       
    }
}
