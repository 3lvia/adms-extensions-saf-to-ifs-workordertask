using System.Diagnostics.CodeAnalysis;
using Elvia.Configuration.HashiVault;

namespace IfsResponseServices.Vault;

[ExcludeFromCodeCoverage(Justification = "This is a thin wrapper for the live vault")]
public class HashiVaultWrapper : IHashiVaultWrapper
{
    public string EnsureHasValue(string path)
    {
        return HashiVault.EnsureHasValue(path);
    }

    public string GetGenericSecret(string path, bool canBeNull)
    {
        return HashiVault.GetGenericSecret(path, canBeNull);
    }
}