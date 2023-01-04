using adms_extensions_saf_to_ifs_workordertask.PerformMessages;
using Microsoft.Extensions.DependencyInjection;
using ServicesIfs;
using ServicesUniqueId;

namespace SafToIfsWorkOrderTask.ServiceCollectionExtensions;

public static class IfsCloudMessagesCollectionExtensions
{
    public static IServiceCollection AddIfsCloudMessageServices(this IServiceCollection services)
    {
        services.AddHttpClient<IfsCloudService>();
        services.AddSingleton<IIfsCloudService, IfsCloudService>();
        services.AddHttpClient<UniqueIdService>();
        services.AddSingleton<IUniqueIdService, UniqueIdService>();

        return services;
    }
}