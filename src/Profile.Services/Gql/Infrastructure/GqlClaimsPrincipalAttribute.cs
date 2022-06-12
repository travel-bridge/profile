using System.Security.Claims;

namespace Profile.Services.Gql.Infrastructure;

public class GqlClaimsPrincipalAttribute : GlobalStateAttribute
{
    public GqlClaimsPrincipalAttribute() : base(nameof(ClaimsPrincipal))
    {
    }
}