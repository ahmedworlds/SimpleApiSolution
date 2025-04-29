using Microsoft.AspNetCore.Http;
using System;
using System.Text.Json;
using System.Threading.Tasks;

namespace SimpleApi.Middleware
{
    /// <summary>
    /// Global middleware for handling all API errors including exceptions and 404 (Not Found) errors
    /// </summary>
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        /// <summary>
        /// Handles the HTTP request and catches any errors that occur
        /// </summary>
        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                // Pass the request to the next middleware in the pipeline
                await _next(context);

                // Check for 404 errors that happen when no endpoint matches the request
                // This happens after all other middleware has executed
                if (context.Response.StatusCode == 404 && !context.Response.HasStarted)
                {
                    // Set content type to JSON (important for API clients)
                    context.Response.ContentType = "application/json";
                    
                    // Create a structured error response with all relevant information
                    var errorResponse = new
                    {
                        error = $"Status Code: 404",
                        statusCode = 404,
                        path = context.Request.Path.ToString(),
                        method = context.Request.Method,
                        timestamp = DateTime.UtcNow.ToString("o")
                    };

                    // Serialize and write the JSON response
                    var json = JsonSerializer.Serialize(errorResponse);
                    await context.Response.WriteAsync(json);
                }
            }
            catch (Exception ex)
            {
                // Handle any unhandled exceptions thrown during request processing
                if (!context.Response.HasStarted)
                {
                    // Set appropriate error status code
                    context.Response.StatusCode = 500;
                    context.Response.ContentType = "application/json";
                    
                    // Include the full exception details in the response
                    var errorResponse = new
                    {
                        error = ex.ToString(), // Full exception including stack trace
                        statusCode = 500,
                        path = context.Request.Path.ToString(),
                        method = context.Request.Method,
                        timestamp = DateTime.UtcNow.ToString("o")
                    };

                    // Serialize and write the JSON response
                    var json = JsonSerializer.Serialize(errorResponse);
                    await context.Response.WriteAsync(json);
                }
                // If response already started, we can't modify it - the error will propagate to the host
            }
        }
    }
}