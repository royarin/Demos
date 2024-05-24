namespace CartAPI.Models
{
    public class LineItem
    {
        public Product Product { get; set; }
        public int Quantity { get; set; }
        public double TotalPrice
        {
            get
            {
                return Math.Round(Quantity * Product.Price, 2);
            }
        }
    }
}
