using System;
using System.Collections.Generic;
using Microsoft.Azure.Documents;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;

namespace FunctionCosmosDB
{
    public static class CosmosTrigger
    {
        [FunctionName("CosmosTrigger")]
        public static void Run([CosmosDBTrigger(
            databaseName: "appdb",
            collectionName: "customer",
            ConnectionStringSetting = "connection-string",
            LeaseCollectionName = "leases", CreateLeaseCollectionIfNotExists =true)]IReadOnlyList<Document> input, ILogger log)
        {
            if (input != null && input.Count > 0)
            {
                //log.LogInformation("Documents modified " + input.Count);
                //log.LogInformation("First document Id " + input[0].Id);
                foreach(var course in input)
                {
                    Console.WriteLine(course.GetPropertyValue<string>("customerid"));
                    Console.WriteLine(course.GetPropertyValue<string>("coursename"));
                    Console.WriteLine(course.GetPropertyValue<string>("id"));
                    Console.WriteLine(course.GetPropertyValue<decimal>("rating"));
                }
            }
        }
    }
}
