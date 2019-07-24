using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cotenetapp.Models
{
    public class CategoryProduct
    {
        public List<Category> Categories { get; set; }
        public List<Product> Products { get; set; }
    }
}
