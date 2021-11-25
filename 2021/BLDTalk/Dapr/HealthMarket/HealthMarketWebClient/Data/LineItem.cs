using System.Collections.Generic;

namespace HealthMarketWebClient.Data
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