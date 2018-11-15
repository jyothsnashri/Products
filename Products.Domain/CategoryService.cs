using Products.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Products.Domain
{
   public class CategoryService : ICategory
    {

        private PetraProductsEntities _PetraProductsEntities;

        public CategoryService()
        {
            _PetraProductsEntities = new PetraProductsEntities();
        }

        //Calling through linq Query directly.
        public List<Category> GetActiveCategory(List<Category> CategoryList)
        {
            var Categories = _PetraProductsEntities.Categories.OrderBy(a => a.Category1).ToList();
            CategoryList = AddCategoryInList(Categories, CategoryList);
            return CategoryList;
        }


        //Added data Category list.
        public List<Category> AddCategoryInList(dynamic ListDynCategory, List<Category> CategoryList)
        {
            if (ListDynCategory.Count > 0)
            {
                foreach (var CategoryDyn in ListDynCategory)
                {
                    CategoryList.Add(new Category { ID = CategoryDyn.ID, Category1 = CategoryDyn.Category1, Status = CategoryDyn.Status });
                }
            }
            return CategoryList;
        }


        public int? GetActiveCategoryID(string Categoryname)
        {
            int? CategoryID = 0;
            var Categorys = _PetraProductsEntities.Categories.Where(a => a.Category1 == Categoryname).ToList();
            if (Categorys.Count > 0)
                CategoryID = Categorys[0].ID;
            return CategoryID;
        }

    }
}
