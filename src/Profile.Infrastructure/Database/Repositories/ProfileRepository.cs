using Profile.Domain.Aggregates.ProfileAggregate;
using ProfileAggregate = Profile.Domain.Aggregates.ProfileAggregate;

namespace Profile.Infrastructure.Database.Repositories;

public class ProfileRepository : RepositoryBase<DataContext, ProfileAggregate.Profile, string>, IProfileRepository
{
    public ProfileRepository(DataContext context) : base(context)
    {
    }
}