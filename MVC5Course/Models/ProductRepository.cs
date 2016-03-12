using System;
using System.Linq;
using System.Collections.Generic;

namespace MVC5Course.Models
{
    public class ProductRepository : EFRepository<Product>, IProductRepository
    {
        public Product Get(int? id)
        {
            if (!id.HasValue)
            {
                throw new ArgumentNullException("id is null");
            }
            return base.All().Where(x => x.ProductId == id).FirstOrDefault();
        }
    }

    public interface IProductRepository : IRepository<Product>
    {
        Product Get(int? id);
    }
}