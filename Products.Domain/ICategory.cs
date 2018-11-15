using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Products.Domain
{
    public interface ICategory
    {
        //Read
        List<Category> GetActiveCategory(List<Category> Categorieslist);


        List<Category> AddCategoryInList(dynamic ListDynCategory, List<Category> CategoryList);

        int? GetActiveCategoryID(string Categoryname);


    }
}
