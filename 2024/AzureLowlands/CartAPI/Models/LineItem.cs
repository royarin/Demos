namespace CartAPI.Models
{
    public class LineItem
    {
        public Product Product { get; set; }
        public int Quantity { get; set; }
        public decimal TotalPrice
        {
            get
            {
                return (decimal)(Quantity * Product.Price);
            }
        }
    }
}
