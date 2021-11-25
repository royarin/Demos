namespace HealthMarketWebClient.Data
{
    public class Product
    {
        public string Id { get; set; }
        public string SKU { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public string Filename { get; set; }
        public int Height { get; set; }
        public int Width { get; set; }
        public double Price { get; set; }
        public int Rating { get; set; }

    }
}