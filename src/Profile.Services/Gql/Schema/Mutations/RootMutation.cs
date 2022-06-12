using HotChocolate.AspNetCore.Authorization;
using Profile.Services.Infrastructure;

namespace Profile.Services.Gql.Schema.Mutations;

public class RootMutation
{
    [GraphQLName("profiles"), Authorize(Policy = AuthorizePolicies.WriteProfile)]
    public ProfileMutation ProfileMutation => new();
}