using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    //IProductDal interface implement ediyoruz.
    //Interface, bir classın sağlaması gereken yeteneklerin beyanıdır.
    //Ürün listesi oluştuyoruz. Metotlsr dısında tanımladık global değişkendir.(_product)

   
    public class InMemoryProductDal : IProductDal
    {
        List<Product> _products;
        // ctor ile bellekte referans alınca çalışacak olan bloktur.
        public InMemoryProductDal()
        {
            _products = new List<Product>
            {
            new Product {CategoryId =1, ProductId=1, ProductName="Bardak",UnitPrice=15, UnitsInStock =15},
            new Product {CategoryId =1, ProductId=2, ProductName="Kamera",UnitPrice=500, UnitsInStock =3},
            new Product {CategoryId =1, ProductId=3, ProductName="Telefon",UnitPrice=1500, UnitsInStock =2},
            new Product {CategoryId =1, ProductId=4, ProductName="Klavye",UnitPrice=150, UnitsInStock =65},
            new Product {CategoryId =1, ProductId=5, ProductName="Fare",UnitPrice=85, UnitsInStock =1},

            };
        }
        public void Add(Product product)
        {
            _products.Add(product);
        }

        public void Delete(Product product)
        {

            // o an göderdiğim id, paramteryle gönderdiğim id eşitse referans numarasını eşitler.
            Product productToDelete = _products.SingleOrDefault(p => p.ProductId == product.ProductId);
            _products.Remove(productToDelete);
        }


        public void Update(Product product)
        {
            // Gönderdiğim ürün id'sine sahip olan listedeki ürünü bul. Güncellemek için.(Amaç ref. bulmak)
            Product productToUpdate = _products.SingleOrDefault(p => p.ProductId == product.ProductId);
            productToUpdate.ProductName = product.ProductName;
            //gönderdiğim id'yi producttoUpdatein id'si yapabilirim.
            productToUpdate.CategoryId = product.CategoryId;
            productToUpdate.UnitPrice = product.UnitPrice;
            productToUpdate.UnitsInStock = product.UnitsInStock;
        }
        public List<Product> GetAllByCategory(int categoryId)
        {
            return _products.Where(p => p.CategoryId == categoryId).ToList();
        }

        public List<Product> GetAll()
        {
           return _products;
        }

        public List<Product> GetAll(Func<object, bool> p)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public Product Get(Expression<Func<Product, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<ProductDetailDto> GetProductDetails()
        {
            throw new NotImplementedException();
        }
    }
}
