using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.Azure.Documents;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace OrderFunction
{
    public static class Orders
    {
        [FunctionName("GetOrders")]
        public static async Task<IActionResult> GetOrders(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = "orders")] HttpRequest req,
            [CosmosDB("staging", "order", SqlQuery = "SELECT * FROM c", ConnectionStringSetting = "cosmosConnection")] IEnumerable<Order> orders,
            ILogger log)
        {
            
            if (orders == null)
                return new NoContentResult();
            if(orders.Count() == 0)
                return new NoContentResult();
            return new OkObjectResult(orders);
        }
    }
}
