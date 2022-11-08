
using Elvia.Configuration.HashiVault;

namespace ServicesIfs
{
    public class ClientCredentialsConfiguration : IClientCredentialsConfiguration
    {
        public string ClientId { get; init; } = HashiVault.EnsureHasValue("adms-extensions/kv/elvid/adms-extensions-saf-to-ifs-workordertask/clientid");
        public string ClientSecret { get; init; } = HashiVault.EnsureHasValue("adms-extensions/kv/elvid/adms-extensions-saf-to-ifs-workordertask/clientsecret");
        public string TokenEndpoint { get; init; } = HashiVault.EnsureHasValue("adms-extensions/kv/elvid/adms-extensions-saf-to-ifs-workordertask/tokenendpoint");


        //public string ClientId { get; init; } = HashiVault.EnsureHasValue("adms-extensions/kv/elvid/adms-extensions-saf-to-sesam-api/clientid");
        //public string ClientSecret { get; init; } = HashiVault.EnsureHasValue("adms-extensions/kv/elvid/adms-extensions-saf-to-sesam-api/clientsecret");
        //public string TokenEndpoint { get; init; } = HashiVault.EnsureHasValue("adms-extensions/kv/elvid/adms-extensions-saf-to-sesam-api/tokenendpoint");


    }
}

