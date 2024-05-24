namespace HealthMarket.Data
{
    public class Cart
    {
        public List<LineItem> LineItems { get; set; }
        public double TotalPrice { get; set; }
    }
}
