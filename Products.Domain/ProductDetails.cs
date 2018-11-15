using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Products.Domain
{
    public class ProductDetails
    {
        public List<Category> Categorys { get; set; }
        public Product Products { get; set; }
    }
}
