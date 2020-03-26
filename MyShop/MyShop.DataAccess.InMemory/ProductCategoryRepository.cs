using MyShop.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.DataAccess.InMemory
{
    public class ProductCategoryRepository
    {
        ObjectCache cache = MemoryCache.Default;
        List<ProductCategory> productCatagories;

        public ProductCategoryRepository()
        {
            productCatagories = cache["productCatagories"] as List<ProductCategory>;
            if (productCatagories == null)
            {
                productCatagories = new List<ProductCategory>();
            }

        }

        public void Commit()
        {
            cache["productCatagories"] = productCatagories;
        }

        public void Insert(ProductCategory p)
        {
            productCatagories.Add(p);
        }

        public void Update(ProductCategory product)
        {
            ProductCategory productToUpdate = productCatagories.Find(p => p.Id == product.Id);

            if (productToUpdate != null)
            {
                productToUpdate = product;
            }
            else
            {
                throw new Exception("Product Category Not Found");
            }



        }

        public ProductCategory Find(string Id)
        {
            ProductCategory product = productCatagories.Find(p => p.Id == Id);

            if (product != null)
            {
                return product;
            }
            else
            {
                throw new Exception("Product Category Not Found");
            }

        }

        public IQueryable<ProductCategory> Collection()
        {
            return productCatagories.AsQueryable();
        }

        public void Delete(string Id)
        {
            ProductCategory productToDelete = productCatagories.Find(p => p.Id == Id);

            if (productToDelete != null)
            {
                productCatagories.Remove(productToDelete);
            }
            else
            {
                throw new Exception("Product Category Not Found");
            }

        }
    }
}
