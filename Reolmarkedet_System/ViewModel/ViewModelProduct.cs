using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Reolmarkedet_System.Model;

namespace Reolmarkedet_System.ViewModel
{
    public class ViewModelProduct
    {
        public static void insertProduct(Product product) 
        {
            Model.Product.insertProductInDb(product);
   
        }
    }
}
