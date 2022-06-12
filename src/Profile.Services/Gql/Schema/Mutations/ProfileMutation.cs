using System.Security.Claims;
using MediatR;
using Profile.Application.Commands;
using Profile.Application.Responses;
using Profile.Services.Gql.Infrastructure;
using Profile.Services.Gql.Schema.Requests;
using Profile.Services.Infrastructure;

namespace Profile.Services.Gql.Schema.Mutations;

public class ProfileMutation
{
    [GraphQLName("save")]
    public async Task<OperationResponse> SaveAsync(
        [GqlClaimsPrincipal] ClaimsPrincipal claimsPrincipal,
        [Service] IMediator mediator,
        SaveProfileRequest request)
    {
        var id = claimsPrincipal.GetUserId();
        var command = new SaveProfileCommand(
            id,
            new Domain.Aggregates.Optional<string?>(request.Name, request.Name.HasValue),
            new Domain.Aggregates.Optional<string?>(request.Surname, request.Surname.HasValue),
            new Domain.Aggregates.Optional<string?>(request.Description, request.Description.HasValue),
            new Domain.Aggregates.Optional<bool?>(request.IsGuide, request.IsGuide.HasValue),
            new Domain.Aggregates.Optional<bool?>(request.IsTourist, request.IsTourist.HasValue));
        await mediator.Send(command);

        return OperationResponse.Success;
    }
}