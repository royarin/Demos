using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Threading.Tasks;

namespace NotificationAPI.Models
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
