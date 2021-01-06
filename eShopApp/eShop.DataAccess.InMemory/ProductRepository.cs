using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Caching;
using eShop.Core.Models;

namespace eShop.DataAccess.InMemory
{
    public class ProductRepository
    {
        ObjectCache cache = MemoryCache.Default;
        List<Product> products;
        public ProductRepository()
        {
            products = new List<Product>();
            if (products == null)
            {
                products = new List<Product>();
            }
        }
        public void Comit()
        {
            cache["products"] = products;
        }
        public void Insert(Product p)
        {
            products.Add(p);
        }
        public void Update(Product product)
        {
            Product productToUpdate = products.Find(p => p.ID == product.ID);
            if(productToUpdate != null)
            {
                productToUpdate = product;
            }
            else
            {
                throw new Exception("NOT FOUND");
            }
        }
        public Product Find(string ID)
        {
            Product product = products.Find(p => p.ID == ID);
            if (product != null)
            {
                return product;
            }
            else
            {
                throw new Exception("NOT FOUND");
            }
        }
        public IQueryable<Product> Collection()
        {
            return products.AsQueryable();
        }
        public void Delete(string ID)
        {
            Product productToDelete = products.Find(p => p.ID == ID);
            if (productToDelete != null)
            {
                products.Remove(productToDelete);
            }
            else
            {
                throw new Exception("NOT FOUND");
            }
        } 
    }
}
