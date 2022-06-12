using Profile.Domain.Aggregates;
using Profile.Domain.Aggregates.ProfileAggregate;
using Profile.Infrastructure.Database.Repositories;

namespace Profile.Infrastructure.Database;

public class RepositoryRegistry : IRepositoryRegistry
{
    public RepositoryRegistry(DataContext dataContext)
    {
        Profile = new ProfileRepository(dataContext);
    }
    
    public IProfileRepository Profile { get; }
}