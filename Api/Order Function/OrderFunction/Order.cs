using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrderFunction
{
    public partial class Order
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("orderid")]
        public string OrderId { get; set; }

        [JsonProperty("customerid")]
        public string Customerid { get; set; }

        [JsonProperty("reference")]
        public string Reference { get; set; }

        [JsonProperty("deliverydate")]
        public DateTime Deliverydate { get; set; }

        [JsonProperty("orderlines")]
        public List<Orderline> Orderlines { get; set; }
    }

    public partial class Orderline
    {
        [JsonProperty("article")]
        public string Article { get; set; }

        [JsonProperty("count")]
        public long Count { get; set; }
    }
}
