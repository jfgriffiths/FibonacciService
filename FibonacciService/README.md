# FibonacciService

An Azure Functions application that calculates Fibonacci numbers via an HTTP endpoint.

## Endpoint

### GET /api/FibonacciResult

Calculates the Fibonacci number for a given iteration.

**Query Parameters:**

| Parameter   | Type | Required | Description                          |
|-------------|------|----------|--------------------------------------|
| `iteration` | int  | Yes      | The Fibonacci iteration to calculate |

**Responses:**

| Status Code | Description                              |
|-------------|------------------------------------------|
| 200 OK      | Returns the calculated Fibonacci number  |
| 400 Bad Request | Invalid or missing iteration value   |

**Example:**

```
GET /api/FibonacciResult?iteration=10
```

Response: `55`

## Prerequisites

- [.NET 10 SDK](https://dotnet.microsoft.com/download)
- [Azure Functions Core Tools](https://learn.microsoft.com/azure/azure-functions/functions-run-tools)

## Getting Started

1. Clone the repository.
2. Add your Application Insights connection string to `local.settings.json`:

   ```json
   {
	 "IsEncrypted": false,
	 "Values": {
	   "AzureWebJobsStorage": "UseDevelopmentStorage=true",
	   "FUNCTIONS_WORKER_RUNTIME": "dotnet-isolated",
	   "APPLICATIONINSIGHTS_CONNECTION_STRING": "<your-connection-string>"
	 }
   }
   ```

3. Run the function app:

   ```bash
   func start
   ```

## Project Structure

```
FibonacciService/
├── Function/
│   └── FibonacciResult.cs      # HTTP trigger function
├── Model/
│   └── FibonacciRequest.cs     # Request model
├── Utilities/
│   └── Fibonacci.cs            # Fibonacci calculation logic
├── Program.cs                  # Application entry point
├── host.json
└── local.settings.json
```
