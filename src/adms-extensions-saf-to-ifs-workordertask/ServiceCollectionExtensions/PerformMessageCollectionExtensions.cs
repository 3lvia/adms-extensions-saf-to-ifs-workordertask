using adms_extensions_saf_to_ifs_workordertask.PerformMessages;
using Microsoft.Extensions.DependencyInjection;
using ServicesIfs;


namespace SafToIfsWorkOrderTask.ServiceCollectionExtensions;

public static class PerformMessagesCollectionExtensions
{
    public static IServiceCollection AddPerformMessageServices(this IServiceCollection services)
    {
        services.AddSingleton<IPerformMessageMaintenanceOrder, PerformMessageMaintenanceOrder>();

        return services;
    }
}