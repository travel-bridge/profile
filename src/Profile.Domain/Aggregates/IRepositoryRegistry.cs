using Profile.Domain.Aggregates.ProfileAggregate;

namespace Profile.Domain.Aggregates;

public interface IRepositoryRegistry
{
    IProfileRepository Profile { get; }
}