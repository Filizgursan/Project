using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    //kategoriyle ilgili dış dünyaya neyi servis etmek istiyorsan o operasyonları yazıyorum.
    public interface ICategoryService
    {
        List<Category> GetAll();
        Category GetById(int categoryId);
    }
}
