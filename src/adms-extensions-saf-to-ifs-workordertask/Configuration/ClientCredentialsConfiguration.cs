
//using Castle.Core.Configuration;
using Elvia.Configuration.HashiVault;
using IfsResponseServices.Vault;
using Microsoft.Extensions.Configuration;

namespace ServicesIfs
{
    public class ClientCredentialsConfiguration : IClientCredentialsConfiguration
    {
        private readonly IConfiguration _configuration;
        private readonly IHashiVaultWrapper _hashiVaultWrapper;

        public ClientCredentialsConfiguration(IConfiguration configuration,
            IHashiVaultWrapper hashiVaultWrapper)
        {
            _configuration = configuration;
            _hashiVaultWrapper = hashiVaultWrapper;
        }

        public string ClientId()
        {
            return ValueFromVault("Vault:ClientId");
        }

        public string ClientSecret()
        {
            return ValueFromVault("Vault:ClientSecret");
        }

        public string TokenEndpoint()
        {
            return ValueFromVault("Vault:TokenEndpoint");
        }
        private string ValueFromVault(string key)
        {
            var path = _configuration[key];
            var value = _hashiVaultWrapper.EnsureHasValue(path);
            return value;
        }

    }
}

