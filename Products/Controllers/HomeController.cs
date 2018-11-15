using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Products.Domain;

namespace Products.Controllers
{


    public class HomeController : Controller
    {


        
        private List<Category> _CategoriesListObj = new List<Category>();
        private List<Product> _ProductListObj = new List<Product>();
        private Product _ProductObj = new Product();
        private ProductDetails _ProductDetailsObj = new ProductDetails();


        IProducts _iProduct;
        ICategory _icategory;
        IProductDetails _iProductDetails;


        public HomeController(IProducts iProduct, ICategory icategory, IProductDetails iProductDetails)
        {
            _iProduct = iProduct;
            _icategory = icategory;
            _iProductDetails = iProductDetails;
        }

        public ActionResult Index()
        {
            try
            {
                // passing the object to make unit test case more fexible.
                _CategoriesListObj = _icategory.GetActiveCategory(_CategoriesListObj);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.InnerException.ToString());

            }
            return View(_CategoriesListObj);
        }


       
        [HttpGet]
        public ActionResult Details(string Id)
        {
            try
            {
                // passing the object to make unit test case more fexible.
                int? CategorysID = _icategory.GetActiveCategoryID(Id);
                _ProductListObj = _iProduct.GetProduct(CategorysID, _ProductListObj);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.InnerException.ToString());

            }
            return View(_ProductListObj);
        }




        [HttpGet]
        public ActionResult ProductDetails(int Id)
        {
            try
            {
                // passing the object to make unit test case more fexible.
                _ProductObj = _iProduct.GetProductDetails(Id, _ProductObj);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.InnerException.ToString());

            }
            return View(_ProductObj);
        }


        [HttpGet]
        public ActionResult ProductDetailsEdit(int Id)
        {
            try
            {
                // passing the object to make unit test case more fexible.
                _ProductDetailsObj.Products = _iProduct.GetProductDetails(Id, _ProductObj);
                _ProductDetailsObj.Categorys = _icategory.GetActiveCategory(_CategoriesListObj);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.InnerException.ToString());

            } 
            return View(_ProductDetailsObj);
        }



        [HttpPost]
        public ActionResult ProductDetailsUpdate(ProductDetails productDetailsObj)
        {
            try
            {
                
              _iProductDetails.UpdateProductDetails(productDetailsObj);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.InnerException.ToString());

            }
            return RedirectToAction("Details");
        }

    }
}