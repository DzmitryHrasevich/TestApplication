namespace WebApp.Middlewares;

public class LoggingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<LoggingMiddleware> _logger;

    public LoggingMiddleware(RequestDelegate next, ILogger<LoggingMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task Invoke(HttpContext context)
    {
        _logger.LogInformation("Incoming request: {RequestMethod} {RequestPath}", context.Request.Method, context.Request.Path);

        var originalBodyStream = context.Response.Body;

        using var responseBody = new MemoryStream();
        context.Response.Body = responseBody;

        await _next(context);

        _logger.LogInformation("Outgoing response: {ResponseStatusCode}", context.Response.StatusCode);

        await responseBody.CopyToAsync(originalBodyStream);
    }
}