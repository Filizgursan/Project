using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfProductDal : IProductDal
    {
        public void Add(Product entity)
        {
            //using içine yazılan nesneler, using bitince garbage coll. geliyor ve atılıyor.
            using (NorthwindContext context=new NorthwindContext())
            {
                // Verikaynağından bir nesneyi eşleştir. Direkt ekleme yapıcak.
                //Verikaynağı ile ilişkilendirir.
                var addedEntity = context.Entry(entity);
                addedEntity.State = EntityState.Added;
                //İşlemi yapar.
                context.SaveChanges();
            }
        }

        public void Delete(Product entity)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
               
                var deletedEntity = context.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        //Tek data getirecek GEt'ten dolayı;
        public Product Get(Expression<Func<Product, bool>> filter)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                //
                return context.Set<Product>().SingleOrDefault(filter);
            }

        }

        public List<Product> GetAll(Func<object, bool> p)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                // select* from products döndürüuyor ve Listeye dönüştürüyor.
                //filtre null'sa; context.Set<Product>().ToList()
                //filtre varsa, filtreleyip verir;context.Set<Product>().Where(filter).ToList();

                return filter == null 
                ? context.Set<Product>().ToList()
                :context.Set<Product>().Where(filter).ToList();
                

            }
        }

        public void Update(Product entity)
        {
            using (NorthwindContext context = new NorthwindContext())
            {

                var updatedEntity = context.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
