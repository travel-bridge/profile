using System.Security.Claims;
using Profile.Application.Queries;
using Profile.Application.Responses;
using Profile.Services.Gql.Infrastructure;
using Profile.Services.Infrastructure;

namespace Profile.Services.Gql.Schema.Queries;

public class ProfileQuery
{
    [GraphQLName("byId")]
    public async Task<ProfileResponse?> GetByIdAsync(
        [GqlClaimsPrincipal] ClaimsPrincipal claimsPrincipal,
        [Service] IProfileQueries profileQueries)
    {
        var id = claimsPrincipal.GetUserId();
        var response = await profileQueries.GetByIdAsync(id);
        return response;
    }
}