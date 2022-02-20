using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace Database
{
    public class DummyTenantPovider : ITenantProvider
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public DummyTenantPovider(IHttpContextAccessor httpContextAccessor)
        {
            this._httpContextAccessor = httpContextAccessor;
        }

        public string GetTenantId()
        {
            var tenantId = this._httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(x => x.Type == "Tenant")?.Value;
            if (tenantId == null)
            {
                tenantId = this._httpContextAccessor.HttpContext.Request.Headers["TenantId"];
            }

            return tenantId;
        }
    }
}