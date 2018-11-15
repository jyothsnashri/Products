using System;
using System.Collections.Generic;


namespace Products.Domain
{
   public interface IProducts
    {
        //Edit
        Product EditProduct(int ProductID, Product EditProductDetails);
        //Read
        List<Product> GetProduct(int? CategoryID, List<Product> ProductDetails);
        //Read
        Product GetProductDetails(int ProductID, Product ProductDetails);

        Product AddProductDetails(dynamic ListDynProduct, Product ProductDetails);

        List<Product> AddProductInList(dynamic ListDynProduct, List<Product> ProductList);
      
    }
}
