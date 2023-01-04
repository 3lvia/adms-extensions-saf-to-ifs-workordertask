namespace IfsResponseServices.Vault;

public interface IHashiVaultWrapper
{
    public string EnsureHasValue(string path);
    public string GetGenericSecret(string path, bool canBeNull);
}