using System.Collections.Generic;

namespace HealthMarketWebClient.Data
{
    public class Cart
    {
        public IList<LineItem> LineItems { get; set; }
    }
}