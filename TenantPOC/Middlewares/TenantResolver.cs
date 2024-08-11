using TenantPOC.Services;

namespace TenantPOC.Middlewares
{
    public class TenantResolver
    {
        private readonly RequestDelegate _next;

        public TenantResolver(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context, ICurrentTenantService currentTenantService)
        {
            context.Request.Headers.TryGetValue("tenant", out var tenantFromHeader);
            if (!string.IsNullOrEmpty(tenantFromHeader))
            {
                await currentTenantService.SetTenant(tenantFromHeader);
            }
            await _next(context);
        }
    }
}
