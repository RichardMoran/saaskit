using Microsoft.AspNet.Http;

namespace SaasKit.Multitenancy.Internal
{
    public class HttpContextTenantAccessor<TTenant> : ITenantAccessor<TTenant>
    {
        private IHttpContextAccessor httpContextAccessor;

        public HttpContextTenantAccessor(IHttpContextAccessor httpContextAccessor)
        {
            Ensure.Argument.NotNull(httpContextAccessor, nameof(httpContextAccessor));
            this.httpContextAccessor = httpContextAccessor;
        }

        public TTenant Tenant
        {
            get
            {
                return httpContextAccessor.HttpContext.GetTenant<TTenant>();
            }
        }
    }
}
