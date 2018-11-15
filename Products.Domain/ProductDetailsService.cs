using Products.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Products.Domain
{
  public class ProductDetailsService : IProductDetails
    {
        private PetraProductsEntities _PetraProductsEntities;

        public ProductDetailsService()
        {
            _PetraProductsEntities = new PetraProductsEntities();
        }

        public void UpdateProductDetails(ProductDetails ProductDetailsobj)
        {
             _PetraProductsEntities.UpdProduct(ProductDetailsobj.Products.Name.Trim(), ProductDetailsobj.Products.Number.Trim(), ProductDetailsobj.Products.Description.Trim(), ProductDetailsobj.Products.CategoryID, ProductDetailsobj.Products.Price, ProductDetailsobj.Products.ID);
        }

    }
}
