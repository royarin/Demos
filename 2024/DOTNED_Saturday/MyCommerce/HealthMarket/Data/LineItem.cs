namespace HealthMarket.Data
{
    public class LineItem
    {
        public Product Product { get; set; }
        public int Quantity { get; set; }
        public double? TotalPrice { get; set; }
    }
}
