using System.Collections.Generic;

namespace CartAPI.Models
{
    public class Cart
    {
        public IList<LineItem> LineItems { get; set; }
    }
}