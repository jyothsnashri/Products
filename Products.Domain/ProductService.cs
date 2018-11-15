using System;
using System.Collections.Generic;
using System.Linq;
using Products.Infrastructure;
using System.Configuration;

namespace Products.Domain
{
  public class ProductService : IProducts
    {

        private PetraProductsEntities _PetraProductsEntities;

        public ProductService()
        {
            _PetraProductsEntities = new PetraProductsEntities();
        }

        //Edit
        public Product EditProduct(int id, Product EditProductDetails)
        {

            try
            {
                var Article = _PetraProductsEntities.Products.Where(a => a.ID.Equals(id)).FirstOrDefault();
                if (Article != null)
                {
                    EditProductDetails.ID = Article.ID;
                    EditProductDetails.Name = Article.Name;
                    EditProductDetails.Number = Article.Number;
                   // EditProductDetails.Category = Article.Category.Category1.ToString();
                    EditProductDetails.Description = Article.Description;
                    EditProductDetails.Price = Article.Price;
                    EditProductDetails.ExcludingPrice = (Article.Price % 12.5);
                    EditProductDetails.ID = Article.ID;
                }
            }
            catch(Exception ex)
            {
                

            }
            return EditProductDetails;
        }

        //Read Pulling product details from store procedure
        public List<Product> GetProduct(int? CategoryID, List<Product> ProductList)
        {
            if (CategoryID >= 1)
            {
                var Products = _PetraProductsEntities.GetProducts().Where(a => a.CategoryID == CategoryID).OrderBy(a => a.Name).ToList();
                ProductList = AddProductInList(Products, ProductList);
            }
            else
            {
                var Products = _PetraProductsEntities.GetProducts().OrderBy(a => a.Name).ToList();
                ProductList = AddProductInList(Products, ProductList);
            }
           
            return ProductList;
        }

        //Read Pulling product details from store procedure
        public Product GetProductDetails(int ProductID, Product ProductDetails)
        {
           
                var Products = _PetraProductsEntities.GetProducts().Where(a => a.ID == ProductID).SingleOrDefault();
                ProductDetails = AddProductDetails(Products, ProductDetails);
                return ProductDetails;
        }



        public Product AddProductDetails(dynamic ListDynProduct, Product ProductDetails)
        {
            if (ListDynProduct != null)
            {
                Double Taxes = Convert.ToDouble(ConfigurationManager.AppSettings["Tax"]);
                ProductDetails.ID = ListDynProduct.ID;
                ProductDetails.Number = ListDynProduct.Number;
                ProductDetails.Name = ListDynProduct.Name;
                ProductDetails.Description = ListDynProduct.Description;
                ProductDetails.Price = ListDynProduct.Price;
                ProductDetails.Category = ListDynProduct.Category;
                ProductDetails.CategoryID = ListDynProduct.CategoryID;
                ProductDetails.ExcludingPrice = (double)Math.Round(ListDynProduct.Price) - Math.Round((double)(ListDynProduct.Price * Taxes) / 100);
            }
            return ProductDetails;
        }

        //Added data Category list.
        public List<Product> AddProductInList(dynamic ListDynProduct, List<Product> ProductList)
        {
            if (ListDynProduct.Count > 0)
            {
                foreach (var ProductDyn in ListDynProduct)
                {
                    Double Taxes = Convert.ToDouble(ConfigurationManager.AppSettings["Tax"]);
                    ProductList.Add(new Product
                    {
                        ID = ProductDyn.ID,
                        Number = ProductDyn.Number,
                        Name = ProductDyn.Name,
                        Description = ProductDyn.Description,
                        Price = ProductDyn.Price,
                        Category = ProductDyn.Category,
                        CategoryID = ProductDyn.CategoryID,
                        ExcludingPrice = (double)Math.Round(ProductDyn.Price) - Math.Round((double)(ProductDyn.Price * Taxes) / 100)
                    });

                }
            }
            return ProductList;
        }



    }
}
