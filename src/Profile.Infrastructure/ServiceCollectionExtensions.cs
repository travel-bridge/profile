using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Profile.Domain.Aggregates;
using Profile.Infrastructure.Database;

namespace Profile.Infrastructure;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration)
        => services
            .AddDatabase(configuration);

    private static IServiceCollection AddDatabase(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("ProfileDatabase")
            ?? throw new InvalidOperationException("Connection string is not configured.");

        services.AddDbContext<DataContext>(
            builder => builder.UseNpgsql(
                connectionString,
                options => options.EnableRetryOnFailure(
                    3,
                    TimeSpan.FromSeconds(10),
                    null)));

        services.AddScoped<IRepositoryRegistry, RepositoryRegistry>();
        services.AddScoped<IDataExecutionContext, DataExecutionContext>();
        
        return services;
    }
}