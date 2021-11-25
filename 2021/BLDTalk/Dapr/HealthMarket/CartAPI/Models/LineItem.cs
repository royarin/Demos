using System.Collections.Generic;

namespace CartAPI.Models
{
    public class LineItem
    {
        public Product Product { get; set; }
        public int Quantity { get; set; }
        public double TotalPrice { 
            get{
                return Quantity*Product.Price;
            }
         }
    }
}