
using Business.Abstract;
using Core.Utilities.Results;
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

        public IDataResult<List<Category>> GetAll()
        {
            //iş kodları
            return new SuccessDataResult<List<Category>>( _categoryDal.GetAll());
        }

        public IDataResult<Category> GetById(int categoryId)
        {
            // select* from Categories where  categoryId== 3 demek gibi
            return new SuccessDataResult<Category>(_categoryDal.Get(c => c.CategoryId == categoryId));
        }
    }
}
