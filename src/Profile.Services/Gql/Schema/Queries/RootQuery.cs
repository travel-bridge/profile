using HotChocolate.AspNetCore.Authorization;
using Profile.Services.Infrastructure;

namespace Profile.Services.Gql.Schema.Queries;

public class RootQuery
{
    [GraphQLName("profiles"), Authorize(Policy = AuthorizePolicies.ReadProfile)]
    public ProfileQuery ProfileQuery => new();
}