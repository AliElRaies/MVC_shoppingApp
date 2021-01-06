using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eShop.Core.Models;
using System.Runtime.Caching;


namespace eShop.DataAccess.InMemory
{
    public class ProductCategoryRepository
    {
        ObjectCache cache = MemoryCache.Default;
        List<ProductCategory> productCategories;
        public ProductCategoryRepository()
        {
            productCategories = new List<ProductCategory>();
            if (productCategories == null)
            {
                productCategories = new List<ProductCategory>();
            }
        }
        public void Comit()
        {
            cache["productCategories"] = productCategories;
        }
        public void Insert(ProductCategory p)
        {
            productCategories.Add(p);
        }
        public void Update(ProductCategory productCategory)
        {
            ProductCategory productCategoryToUpdate = productCategories.Find(p => p.ID == productCategory.ID);
            if (productCategoryToUpdate != null)
            {
                productCategoryToUpdate = productCategory;
            }
            else
            {
                throw new Exception("NOT FOUND");
            }
        }
        public ProductCategory Find(string ID)
        {
            ProductCategory productCategory = productCategories.Find(p => p.ID == ID);
            if (productCategory != null)
            {
                return productCategory;
            }
            else
            {
                throw new Exception("NOT FOUND");
            }
        }
        public IQueryable<ProductCategory> Collection()
        {
            return productCategories.AsQueryable();
        }
        public void Delete(string ID)
        {
            ProductCategory productCategoryToDelete = productCategories.Find(p => p.ID == ID);
            if (productCategoryToDelete != null)
            {
                productCategories.Remove(productCategoryToDelete);
            }
            else
            {
                throw new Exception("NOT FOUND");
            }
        }
    }
}
