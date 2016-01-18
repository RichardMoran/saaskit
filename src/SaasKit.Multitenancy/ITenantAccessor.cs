namespace SaasKit.Multitenancy
{
    public interface ITenantAccessor<TTenant>
    {
        TTenant Tenant { get; }
    }
}
