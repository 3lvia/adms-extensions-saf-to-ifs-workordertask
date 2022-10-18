using Microsoft.Extensions.DependencyInjection;
using ServicesIfs;


namespace SafToIfsWorkOrderTask.ServiceCollectionExtensions;

public static class AuthCollectionExtensions
{
    public static IServiceCollection AddAuthServices(this IServiceCollection services)
    {
        services
            .AddSingleton<IClientCredentialsConfiguration, ClientCredentialsConfiguration>()
            .AddSingleton<IAccessTokenService, AccessTokenService>();

        return services;
    }
}