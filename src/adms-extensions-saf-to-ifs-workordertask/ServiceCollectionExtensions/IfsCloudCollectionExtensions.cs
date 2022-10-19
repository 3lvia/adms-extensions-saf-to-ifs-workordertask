using adms_extensions_saf_to_ifs_workordertask.PerformMessages;
using Microsoft.Extensions.DependencyInjection;
using ServicesIfs;


namespace SafToIfsWorkOrderTask.ServiceCollectionExtensions;

public static class IfsCloudMessagesCollectionExtensions
{
    public static IServiceCollection AddIfsCloudMessageServices(this IServiceCollection services)
    {
        services.AddSingleton<IIfsWorkOrder, IfsWorkOrder>();

        return services;
    }
}