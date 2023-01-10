using IfsResponseServices.Vault;
using Microsoft.Extensions.DependencyInjection;
using ServicesIfs;


namespace SafToIfsWorkOrderTask.ServiceCollectionExtensions;

public static class AuthCollectionExtensions
{
    public static IServiceCollection AddAuthServices(this IServiceCollection services)
    {
        services
            .AddSingleton<IHashiVaultWrapper, HashiVaultWrapper>()
            .AddSingleton<IClientCredentialsConfiguration, ClientCredentialsConfiguration>()
            .AddSingleton<IAccessTokenService, AccessTokenService>();
         
        return services;
    }
}