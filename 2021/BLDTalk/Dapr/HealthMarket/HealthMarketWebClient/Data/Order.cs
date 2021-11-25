using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HealthMarketWebClient.Data
{
    public class Order
    {
        public string OrderNumber { get; set; }
        [Required]
        public string DeliveryName { get; set; }
        [Required]
        public string DeliveryAddress1 { get; set; }
        public string DeliveryAddress2 { get; set; }
        [Required]
        public string DeliveryCity { get; set; }
        [Required]
        public string DeliveryPostCode { get; set; }
        [Required]
        public string DeliveryCountry { get; set; }
        public IList<LineItem> LineItems { get; set; }
    }
}