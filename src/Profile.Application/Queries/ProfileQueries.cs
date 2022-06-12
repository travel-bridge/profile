using Npgsql;
using Profile.Application.Responses;
using SqlKata.Compilers;
using SqlKata.Execution;

namespace Profile.Application.Queries;

public class ProfileQueries : IProfileQueries
{
    private readonly string _connectionString;

    public ProfileQueries(string connectionString)
    {
        _connectionString = connectionString;
    }

    public async Task<ProfileResponse?> GetByIdAsync(string id)
    {
        await using var connection = new NpgsqlConnection(_connectionString);
        var compiler = new PostgresCompiler();
        var queryFactory = new QueryFactory(connection, compiler);
        
        var profileQuery = queryFactory
            .Query("profile.Profile as p")
            .Select(
                "p.Id",
                "p.Name",
                "p.Surname",
                "p.Description",
                "p.IsGuide",
                "p.IsTourist")
            .Where("p.Id", "=", id);
        
        var profile = await profileQuery.FirstOrDefaultAsync<ProfileResponse>();
        return profile;
    }
}