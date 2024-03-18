namespace AspNetCore.Application.Middlewares
{
    public class OtherMiddleware(RequestDelegate next)
    {
        public async Task Invoke(HttpContext context, ILogger<OtherMiddleware> logger)
        {
            var correlationId = context.Request.Headers["X-Correlation-ID"].FirstOrDefault();
            //ya da
            correlationId = context.Items["CorrelationId"].ToString();

            NLog.MappedDiagnosticsContext.Set("CorrelationId", correlationId);
            logger.LogDebug("OtherMiddleware Log");

            await next(context);
        }
    }
}
