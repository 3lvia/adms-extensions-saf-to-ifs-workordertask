using System;
using Elvia.Configuration.HashiVault;
using Elvia.KvalitetsportalLogger;
using FakeItEasy;
using IfsResponseServices.Vault;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace SafToIfsWorkOrderTask.ServiceCollectionExtensions;



public static class KvalitetsportalenCollectionExtensions
{
    public static IServiceCollection AddKvalitetsportalenServices(this IServiceCollection services,
        IConfiguration configuration,
        bool isDevelopment,
        IHashiVaultWrapper hashiVaultWrapper)
    {
        var kvalitetsportalClient = CreateKvalitetsportalClient(
            configuration,
            isDevelopment,
            hashiVaultWrapper);

        services.AddSingleton(kvalitetsportalClient);

        return services;
    }

    private static IKvalitetsportalClient CreateKvalitetsportalClient(
        IConfiguration configuration,
        bool isDevelopment,
        IHashiVaultWrapper hashiVaultWrapper)
    {

        var logSuccessfulInvocationsTopic = configuration["Kafka:Kvalitetsportalen:LogSuccessfulInvocationsTopic"];
        var logExceptioninvocationsTopic = configuration["Kafka:Kvalitetsportalen:LogExceptioninvocationsTopic"];
        var logSuccessfulinvocationsLowPriTopic = configuration["Kafka:Kvalitetsportalen:LogSuccessfulinvocationsLowPriTopic"];
        var logExceptioninvocationsLowPriTopic = configuration["Kafka:Kvalitetsportalen:LogExceptioninvocationsLowPriTopic"];

        var sasUriPath = configuration["Vault:Kvalitetsportalen:SasUri"];

        var sasUri = hashiVaultWrapper.GetGenericSecret(sasUriPath, false);

        if (isDevelopment)
        {
            return A.Fake<IKvalitetsportalClient>();
        }

        return new KvalitetsportalClient(
            logSuccessfulInvocationsTopic,
            logExceptioninvocationsTopic,
            logSuccessfulinvocationsLowPriTopic,
            logExceptioninvocationsLowPriTopic,
            new Uri(sasUri));
    }
}






//public static class KvalitetsportalenCollectionExtensions
//{
//    public static IServiceCollection AddKvalitetsportalenServices(this IServiceCollection services, bool isDevelopment)
//    {
//        var kvalitetsportalClient = CreateKvalitetsportalClient(isDevelopment);

//        services.AddSingleton(kvalitetsportalClient);

//        return services;
//    }

//    private static IKvalitetsportalClient CreateKvalitetsportalClient(bool isDevelopment)
//    {

//        var successfulInvocationsTopic = "private.dk.iss.successfulinvocations";
//        var successfulinvocationsLowPriTopic = "private.dk.iss.successfulinvocations_low_priority";
//        var exceptioninvocationsTopic = "private.dk.iss.exceptioninvocations";
//        var exceptioninvocationsLowPriTopic = "private.dk.iss.exceptioninvocations_low_priority";
//        var lobStoreSasUri = HashiVault.EnsureHasValue("adms-extensions/kv/kvalitetsportalen/sasuri");

//        return new KvalitetsportalClient(
//            successfulInvocationsTopic,
//            successfulinvocationsLowPriTopic,
//            exceptioninvocationsTopic,
//            exceptioninvocationsLowPriTopic,
//            new Uri(lobStoreSasUri));

//        //int debug = 2;

//        //if (isDevelopment)
//        //{
//        //    return A.Fake<IKvalitetsportalClient>();
//        //}
//        //var sss = HashiVault.GetGenericSecret("iss/kv/kvalitetsportalen_kafka/successfulinvocations-topic");


//        //var sss = HashiVault.GetGenericSecret("adms-extensions/kv/kvalitetsportalen/successfulinvocations-primary-connection-string");

//        //HashiVault.DebugEnabled = true;

//        //var successfulInvocationsTopic = "private.dk.iss.successfulinvocations";
//        //var successfulinvocationsLowPriTopic = "private.dk.iss.successfulinvocations_low_priority";
//        //var exceptioninvocationsTopic = "private.dk.iss.exceptioninvocations";
//        //var exceptioninvocationsLowPriTopic = "private.dk.iss.exceptioninvocations_low_priority";
//        //var lobStoreSasUri = HashiVault.EnsureHasValue("iss/kv/storage/sastoken/invocationstore/sasuri");


//        //return new KvalitetsportalClient(
//        //    successfulInvocationsTopic,
//        //    successfulinvocationsLowPriTopic,
//        //    exceptioninvocationsTopic,
//        //    exceptioninvocationsLowPriTopic,
//        //    new Uri(lobStoreSasUri));



//        //return new KvalitetsportalClient(
//        //    HashiVault.GetGenericSecret("adms-extensions/kv/kvalitetsportalen/successfulinvocations-primary-connection-string"),
//        //    HashiVault.GetGenericSecret("adms-extensions/kv/kvalitetsportalen/exceptioninvocations-primary-connection-string"),
//        //    HashiVault.GetGenericSecret("adms-extensions/kv/kvalitetsportalen/successfulinvocations-low-priority-primary-connection-string"),
//        //    HashiVault.GetGenericSecret("adms-extensions/kv/kvalitetsportalen/exceptioninvocations-low-priority-primary-connection-string"),
//        //    new Uri(HashiVault.GetGenericSecret("adms-extensions/kv/kvalitetsportalen/sasuri")));


//    }
//}