using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Core.DataAccess
{
    // T'yi sınırlandırmak istiyoruz. Yani yazılan şeyi sınırlandıralım----> Generate Constraint
    // class bir tip değil(int gibi vs.) referans tipidir.
    //IEntitiy : IEntitiy olabilir  veya IEntity iplemente eden bir nesne olabilir. Bİr iş sınıfı başka bir iş sınıfını newlemez.
    // new(): newlenebilir. IEntity newlenemez.
    public interface IEntityRepository<T> where T:class,IEntity,new()
    {
        List<T> GetAll(Expression<Func<T,bool>> filter=null);
        //Tek bir detaya gitmek için; Filter zorunlu;
        T Get(Expression<Func<T, bool>> filter);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);

        //Ürünleri kategoriye göre filtrele
        //List<T> GetAllByCategory(int categoryId);
    }
}
