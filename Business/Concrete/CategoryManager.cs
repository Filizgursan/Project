
using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    // ICategoryService 2 metodu var, dış dünyaya servis etmek istiyor,iş kodlarını buraya yazılır ve implemente gerekli
    public class CategoryManager : ICategoryService
    {
        //business katmanı veri erişimine bağlı ama zaman sonra değişebilier. Entityfraamwork vs. Bu nedenle bağımımlığı min etmeliyiz.
        //Bağımlılığı const. inj. ile yapmalıyım.

        ICategoryDal _categoryDal;

        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        public List<Category> GetAll()
        {
            //iş kodları
            return _categoryDal.GetAll();
        }

        public Category GetById(int categoryId)
        {
            // select* from Categories where  categoryId== 3 demek gibi
            return _categoryDal.Get(c => c.CategoryId == categoryId);
        }
    }
}
