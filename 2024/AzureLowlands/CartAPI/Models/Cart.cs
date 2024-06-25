namespace CartAPI.Models
{
    public class Cart
    {
        public List<LineItem> LineItems { get; set; } = new List<LineItem>();
        public decimal TotalPrice
        {
            get
            {
                decimal total = 0m;
                foreach (var item in LineItems)
                {
                    total += item.TotalPrice;
                }
                return total;
            }
        }

        public decimal TotalDiscount { get; set; }
    }
}
