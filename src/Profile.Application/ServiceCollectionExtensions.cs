using System.Reflection;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Profile.Application.Queries;

namespace Profile.Application;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplication(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddMediatR(Assembly.GetExecutingAssembly());

        var connectionString = configuration.GetConnectionString("ProfileDatabase")
            ?? throw new InvalidOperationException("Connection string is not configured.");
        
        services.AddSingleton<IProfileQueries>(_ => new ProfileQueries(connectionString));

        services.AddLocalization();
        
        return services;
    }
}