namespace SaasKit.Multitenancy
{
    public interface ITenantContextAccessor<TTenant>
    {
        TenantContext<TTenant> TenantContext { get; }
    }
}
