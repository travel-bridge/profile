using Profile.Application.Responses;

namespace Profile.Application.Queries;

public interface IProfileQueries
{
    Task<ProfileResponse?> GetByIdAsync(string id);
}