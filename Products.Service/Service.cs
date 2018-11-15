using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Products.Domain;

namespace Products.Service
{
    public class Service
    {

        private ProductService _ProductCalling;

        public Service(ProductService ProductCalling)
        {
            _ProductCalling = ProductCalling;
        }


       
    }

    }

