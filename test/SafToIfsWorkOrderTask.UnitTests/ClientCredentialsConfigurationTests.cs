using FakeItEasy;
using FakerDotNet;
using IfsResponseServices.Vault;
using Microsoft.Extensions.Configuration;
using ServicesIfs;
using Xunit;

namespace SesamResponseServices.UnitTests;

public class ClientCredentialsConfigurationTests
{
    [Fact]
    public void ClientId_Calls_Configuration()
    {
        // Arrange
        var expected = "Vault:ClientId";
        var basicMocks = new BasicMocks(Faker.Pokemon.Name());
        var underTest = CreateUnderTest(basicMocks);

        // Act
        underTest.ClientId();

        // Assert
        A.CallTo(() => basicMocks.Configuration[expected]).MustHaveHappenedOnceExactly();
    }

    [Fact]
    public void ClientId_Calls_Vault()
    {
        // Arrange
        var expected = Faker.Pokemon.Name();
        var basicMocks = new BasicMocks(expected);
        var underTest = CreateUnderTest(basicMocks);

        // Act
        underTest.ClientId();

        // Assert
        A.CallTo(() => basicMocks.HashiVaultWrapper.EnsureHasValue(expected)).MustHaveHappenedOnceExactly();
    }

    [Fact]
    public void ClientId_Returns_ValueFromVault()
    {
        // Arrange
        var expected = Faker.Pokemon.Name();
        var basicMocks = new BasicMocks(expected);
        var underTest = CreateUnderTest(basicMocks);

        // Act
        var actual = underTest.ClientId();

        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void ClientSecret_Calls_Configuration()
    {
        // Arrange
        var expected = "Vault:ClientSecret";
        var basicMocks = new BasicMocks(Faker.Pokemon.Name());
        var underTest = CreateUnderTest(basicMocks);

        // Act
        underTest.ClientSecret();

        // Assert
        A.CallTo(() => basicMocks.Configuration[expected]).MustHaveHappenedOnceExactly();
    }

    [Fact]
    public void ClientSecret_Calls_Vault()
    {
        // Arrange
        var expected = Faker.Pokemon.Name();
        var basicMocks = new BasicMocks(expected);
        var underTest = CreateUnderTest(basicMocks);

        // Act
        underTest.ClientSecret();

        // Assert
        A.CallTo(() => basicMocks.HashiVaultWrapper.EnsureHasValue(expected)).MustHaveHappenedOnceExactly();
    }

    [Fact]
    public void ClientSecret_Returns_ValueFromVault()
    {
        // Arrange
        var expected = Faker.Pokemon.Name();
        var basicMocks = new BasicMocks(expected);
        var underTest = CreateUnderTest(basicMocks);

        // Act
        var actual = underTest.ClientSecret();

        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void TokenEndpoint_Calls_Configuration()
    {
        // Arrange
        var expected = "Vault:TokenEndpoint";
        var basicMocks = new BasicMocks(Faker.Pokemon.Name());
        var underTest = CreateUnderTest(basicMocks);

        // Act
        underTest.TokenEndpoint();

        // Assert
        A.CallTo(() => basicMocks.Configuration[expected]).MustHaveHappenedOnceExactly();
    }

    [Fact]
    public void TokenEndpoint_Calls_Vault()
    {
        // Arrange
        var expected = Faker.Pokemon.Name();
        var basicMocks = new BasicMocks(expected);
        var underTest = CreateUnderTest(basicMocks);

        // Act
        underTest.TokenEndpoint();

        // Assert
        A.CallTo(() => basicMocks.HashiVaultWrapper.EnsureHasValue(expected)).MustHaveHappenedOnceExactly();
    }

    [Fact]
    public void TokenEndpoint_Returns_ValueFromVault()
    {
        // Arrange
        var expected = Faker.Pokemon.Name();
        var basicMocks = new BasicMocks(expected);
        var underTest = CreateUnderTest(basicMocks);

        // Act
        var actual = underTest.TokenEndpoint();

        // Assert
        Assert.Equal(expected, actual);
    }

    private ClientCredentialsConfiguration CreateUnderTest(BasicMocks basicMocks)
    {
        return new ClientCredentialsConfiguration(basicMocks.Configuration, basicMocks.HashiVaultWrapper);
    }

    private class BasicMocks
    {
        public readonly IConfiguration Configuration;
        public readonly IHashiVaultWrapper HashiVaultWrapper;

        public BasicMocks(string expected)
        {
            Configuration = A.Fake<IConfiguration>();

            A.CallTo(() =>
                    Configuration[A<string>._])
                .Returns(expected);

            HashiVaultWrapper = A.Fake<IHashiVaultWrapper>();
            A.CallTo(() =>
                    HashiVaultWrapper.EnsureHasValue(expected))
                .Returns(expected);
        }
    }
}