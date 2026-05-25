using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Attributes;
using Microsoft.Extensions.Logging;
using FibonacciService.Utilities;
using FibonacciService.Model;

namespace FibonacciService.Function;

public class FibonacciResult
{
    private readonly ILogger<FibonacciResult> _logger;

    public FibonacciResult(ILogger<FibonacciResult> logger)
    {
        _logger = logger;
    }

    [Function("FibonacciResult")]
    [OpenApiOperation(operationId: "GetFibonacciResult", tags: new[] { "Fibonacci" }, Summary = "Calculate Fibonacci number", Description = "Calculates the Fibonacci number for a given iteration.")]
	[OpenApiParameter(name: "iteration", In = Microsoft.OpenApi.Models.ParameterLocation.Query, Required = true, Type = typeof(int), Summary = "Iteration number", Description = "The Fibonacci iteration to calculate.")]
	public async Task<IActionResult> Run([HttpTrigger(AuthorizationLevel.Function, "get")] HttpRequest req)
    {
		if (!int.TryParse(req.Query["iteration"], out int iteration))
		{
			return new BadRequestObjectResult("Missing or invalid 'iteration' query parameter.");
		}

		if (iteration >= 0)
        {
            int result = await new Fibonacci().FibonnacciCalculator(iteration);
			return new OkObjectResult(result);
        }

        return new BadRequestObjectResult("Invalid iteration value.");
    }
}