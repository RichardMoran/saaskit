using Microsoft.AspNet.Http;

namespace SaasKit.Multitenancy.Internal
{
    public class HttpContextTenantContextAccessor<TTenant> : ITenantContextAccessor<TTenant>
    {
        private IHttpContextAccessor httpContextAccessor;

        public HttpContextTenantContextAccessor(IHttpContextAccessor httpContextAccessor)
        {
            Ensure.Argument.NotNull(httpContextAccessor, nameof(httpContextAccessor));
            this.httpContextAccessor = httpContextAccessor;
        }

        public TenantContext<TTenant> TenantContext
        {
            get
            {
                return httpContextAccessor.HttpContext.GetTenantContext<TTenant>();
            }
        }
    }
}
