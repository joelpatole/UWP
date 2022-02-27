using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizza.com
{
    public interface IProduct
    {
        string Name { get; set; }
        int Price { get; set; }
        string Description { get; set; }
         
        Constants.ProductTypes Type { get; set; }
    }
}
