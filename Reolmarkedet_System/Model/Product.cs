using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reolmarkedet_System.Model
{
    public class Product
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public string? Description { get; set; }
        public int Quantity { get; set; }        
        public int ProductGroupID { get; set; }
        public int TenantID { get; set; }
        public int RackID { get; set; }

        public Product(decimal _price, string _description, int _productGroupID, string _productName, int _quantity, int _tenantID, int _rackID)
        {
            Price = _price;
            Description = _description;
            ProductGroupID = _productGroupID;
            ProductName = _productName;
            Quantity = _quantity;
            TenantID = _tenantID;
            RackID = _rackID;
        }
    }
}
