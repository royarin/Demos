namespace HealthMarket.Data
{
    public class Order
    {
        public string OrderNumber { get; set; }
        public string DeliveryName { get; set; }
        public string DeliveryAddress1 { get; set; }
        public string DeliveryAddress2 { get; set; }
        public string DeliveryCity { get; set; }
        public string DeliveryPostCode { get; set; }
        public string DeliveryCountry { get; set; }
        public IList<LineItem> LineItems { get; set; }
    }
}
