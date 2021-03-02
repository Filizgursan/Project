using Core.DataAccess;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    // Orders içinde tablolar barındırırsa, her bir order her bi satırı tanımlar.
    public interface IOrderDal:IEntityRepository<Order>
    {
    }
}
