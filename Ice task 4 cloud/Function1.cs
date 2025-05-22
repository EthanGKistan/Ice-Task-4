using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace Ice_task_4_cloud
{
    public class Function1
    {
        private readonly ILogger<Function1> _logger;

        public Function1(ILogger<Function1> logger)
        {
            _logger = logger;
        }

        [Function("Function1")]
        public IActionResult Run([HttpTrigger(AuthorizationLevel.Function, "get", "post")] HttpRequest req)
        {
            _logger.LogInformation("C# HTTP trigger function processed a request.");

            string name = req.Query["name"];

            if (string.IsNullOrWhiteSpace(name))
            {
                return new BadRequestObjectResult("Please provide a name using the query string, e.g., ?name=John");
            }

            string message = $"Hello, {name}! Your Azure Function executed successfully.";
            return new OkObjectResult(message);
        }
    }
}
