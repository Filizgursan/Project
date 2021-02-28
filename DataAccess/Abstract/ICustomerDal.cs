using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    // Her zaman interfacedasn başlanır.
    // Customer Repository'sidir.
    public interface ICustomerDal: IEntityRepository<Customer>
    {
        
    }
}
