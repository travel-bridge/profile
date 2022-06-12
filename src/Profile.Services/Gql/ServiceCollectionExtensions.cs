using Profile.Services.Gql.Infrastructure;
using Profile.Services.Gql.Schema.Mutations;
using Profile.Services.Gql.Schema.Queries;

namespace Profile.Services.Gql;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddGql(this IServiceCollection services)
    {
        services
            .AddGraphQLServer()
            .AddAuthorization()
            .AddQueryType<RootQuery>()
            .AddMutationType<RootMutation>()
            .UseExceptions()
            .UseTimeout()
            .UseDocumentCache()
            .UseDocumentParser()
            .UseDocumentValidation()
            .UseOperationCache()
            .UseOperationResolver()
            .UseOperationVariableCoercion()
            .UseOperationExecution();

        services.AddErrorFilter<GqlErrorFilter>();
        services.AddHttpResultSerializer<GqlHttpResultSerializer>();
        
        return services;
    }
}