using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Azure.Messaging.WebPubSub;

namespace DF21.Azure.WebPubSubClientToken
{
    public static class GetClientUrl
    {
        [FunctionName("GetClientUrl")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {

            var connString =  Environment.GetEnvironmentVariable("WebPubSubConnString");

            var hubName = Environment.GetEnvironmentVariable("HubName");

            var serviceClient = new WebPubSubServiceClient(connString, hubName);
            var url = serviceClient.GetClientAccessUri(TimeSpan.FromHours(2));

            return new OkObjectResult(url.AbsoluteUri);
        }
    }
}
