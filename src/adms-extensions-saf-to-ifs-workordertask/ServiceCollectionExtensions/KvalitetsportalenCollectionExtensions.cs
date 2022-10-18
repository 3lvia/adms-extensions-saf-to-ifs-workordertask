using System;
using Elvia.Configuration.HashiVault;
using Elvia.KvalitetsportalLogger;
using FakeItEasy;
using Microsoft.Extensions.DependencyInjection;

namespace SafToIfsWorkOrderTask.ServiceCollectionExtensions;

public static class KvalitetsportalenCollectionExtensions
{
    public static IServiceCollection AddKvalitetsportalenServices(this IServiceCollection services, bool isDevelopment)
    {
        var kvalitetsportalClient = CreateKvalitetsportalClient(isDevelopment);

        services.AddSingleton(kvalitetsportalClient);

        return services;
    }

    private static IKvalitetsportalClient CreateKvalitetsportalClient(bool isDevelopment)
    {
        //if (isDevelopment)
        //{
        //    return A.Fake<IKvalitetsportalClient>();
        //}

        return new KvalitetsportalClient(
            HashiVault.GetGenericSecret("adms-extensions/kv/kvalitetsportalen/successfulinvocations-primary-connection-string"),
            HashiVault.GetGenericSecret("adms-extensions/kv/kvalitetsportalen/exceptioninvocations-primary-connection-string"),
            HashiVault.GetGenericSecret("adms-extensions/kv/kvalitetsportalen/successfulinvocations-low-priority-primary-connection-string"),
            HashiVault.GetGenericSecret("adms-extensions/kv/kvalitetsportalen/exceptioninvocations-low-priority-primary-connection-string"),
            new Uri(HashiVault.GetGenericSecret("adms-extensions/kv/kvalitetsportalen/sasuri")),
            true);
    }
}