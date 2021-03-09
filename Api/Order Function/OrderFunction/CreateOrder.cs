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
using Newtonsoft.Json.Linq;

namespace OrderFunction
{
    public static class CreateOrder
    {
        [FunctionName("CreateOrder")]
        public static IActionResult CreateOrders(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = "orders")] HttpRequest req,
            [CosmosDB("staging", "order", ConnectionStringSetting = "cosmosConnection")] out Order docOrder,
            ILogger log)
        {
            docOrder = null;
            if (!req.ContentLength.HasValue ||req.ContentLength == 0)
            {
                return new BadRequestResult();
            }
            var content = req.ReadAsStringAsync().Result;
            var jobject = JObject.Parse(content);
            docOrder = jobject.ToObject<Order>();

            return new CreatedResult("/staging/order/", docOrder);
        }
    }
}
