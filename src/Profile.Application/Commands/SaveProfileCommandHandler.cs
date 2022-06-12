using System.Data;
using MediatR;
using Profile.Domain.Aggregates;
using ProfileAggregate = Profile.Domain.Aggregates.ProfileAggregate;

namespace Profile.Application.Commands;

public record SaveProfileCommand(
    string Id,
    Optional<string?> Name,
    Optional<string?> Surname,
    Optional<string?> Description,
    Optional<bool?> IsGuide,
    Optional<bool?> IsTourist) : IRequest;

public class SaveProfileCommandHandler : AsyncRequestHandler<SaveProfileCommand>
{
    private readonly IDataExecutionContext _dataExecutionContext;

    public SaveProfileCommandHandler(IDataExecutionContext dataExecutionContext)
    {
        _dataExecutionContext = dataExecutionContext;
    }
    
    protected override async Task Handle(SaveProfileCommand command, CancellationToken cancellationToken)
    {
        await _dataExecutionContext.ExecuteWithTransactionAsync(
            async repositories =>
            {
                var profile = await repositories.Profile.GetByIdAsync(command.Id, cancellationToken);
                if (profile is null)
                    await CreateProfileAsync(command, repositories.Profile, cancellationToken);
                else
                    await UpdateProfileAsync(command, profile, repositories.Profile, cancellationToken);
            },
            IsolationLevel.Snapshot,
            cancellationToken);
    }

    private static async Task CreateProfileAsync(
        SaveProfileCommand command,
        ProfileAggregate.IProfileRepository profileRepository,
        CancellationToken cancellationToken)
    {
        var profile = ProfileAggregate.Profile.Create(
            command.Id,
            command.Name.Value,
            command.Surname.Value,
            command.Description.Value,
            command.IsGuide.Value,
            command.IsTourist.Value);

        await profileRepository.CreateAsync(profile, cancellationToken);
    }

    private static async Task UpdateProfileAsync(
        SaveProfileCommand command,
        ProfileAggregate.Profile profile,
        ProfileAggregate.IProfileRepository profileRepository,
        CancellationToken cancellationToken)
    {
        profile.Update(
            command.Name,
            command.Surname,
            command.Description,
            command.IsGuide,
            command.IsTourist);

        await profileRepository.UpdateAsync(profile, cancellationToken);
    }
}