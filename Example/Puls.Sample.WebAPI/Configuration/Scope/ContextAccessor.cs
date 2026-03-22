using Puls.Cloud.Framework.Application;

public class ContextAccessor : IContextAccessor
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public ContextAccessor(IHttpContextAccessor executionContextAccessor)
    {
        _httpContextAccessor = executionContextAccessor;
    }

    private Guid UserId()
    {
        try
        {
            return Guid.Parse(FromClaim(PulsClaimTypes.UserObjectId));
        }
        catch
        {
            return default;
        }
    }

    private string FirstName()
    {
        return FromClaim(PulsClaimTypes.FirstName);
    }

    private string LastName()
    {
        return FromClaim(PulsClaimTypes.LastName);
    }

    private string EmailAddress()
    {
        return FromClaim(PulsClaimTypes.EmailAddress);
    }

    private string UserName()
    {
        try
        {
            return FromClaim(PulsClaimTypes.UserName);
        }
        catch
        {
            return FromClaim("name");
        }
    }

    private string FromClaim(string key)
    {
        var claims = _httpContextAccessor?.HttpContext?.User.Claims;

        return claims
            .Single(x => string.Equals(x.Type, key, StringComparison.OrdinalIgnoreCase))
            .Value;
    }

    Guid IServiceContextAccessor.UserId => UserId();
    string IServiceContextAccessor.UserName => UserName();

    string IServiceContextAccessor.FirstName => FirstName();

    string IServiceContextAccessor.LastName => LastName();

    string IServiceContextAccessor.EmailAddress => EmailAddress();

    public Guid UserObjectId => throw new NotImplementedException();
}