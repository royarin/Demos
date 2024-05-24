namespace CartAPI.Models
{
    public class Cart
    {
        public List<LineItem> LineItems { get; set; } = new List<LineItem>();
        public double TotalPrice
        {
            get
            {
                double total = 0;
                foreach (var item in LineItems)
                {
                    total += item.TotalPrice;
                }
                return total;
            }
        }
    }
}
