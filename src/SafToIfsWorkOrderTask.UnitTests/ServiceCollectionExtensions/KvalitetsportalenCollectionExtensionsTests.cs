using Elvia.KvalitetsportalLogger;
using FakeItEasy;
using FakerDotNet;
using IfsResponseServices.Vault;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SafToIfsWorkOrderTask.ServiceCollectionExtensions;
using Xunit;

namespace SafToIfsWorkOrderTask.UnitTests.ServiceCollectionExtensions;

public class KvalitetsportalenCollectionExtensionsTests
{
    [Fact]
    public void AddKvalitetsportalenServices_Contains_ExpectedNumberOfServices()
    {
        // Arrange
        var expected = 1;
        var basicMocks = new BasicMocks();
        var underTest = CreateUnderTest();

        // Act
        var actual = underTest.AddKvalitetsportalenServices(basicMocks.Configuration, true, basicMocks.HashiVaultWrapper);

        // Assert
        Assert.Equal(expected, actual.Count);
    }

    [Theory]
    [InlineData(typeof(IKvalitetsportalClient))]
    public void AddKvalitetsportalenServices_Contains_ExpectedService(Type type)
    {
       // Arrange
       var basicMocks = new BasicMocks();
       var underTest = CreateUnderTest();

       // Act
       var actual = underTest.AddKvalitetsportalenServices(basicMocks.Configuration, true, basicMocks.HashiVaultWrapper);

       //Assert
       Assert.Equal(1, actual.Count(i => i.ServiceType == type));
    }


    [Theory]
    [InlineData("Kafka:Kvalitetsportalen:LogSuccessfulInvocationsTopic")]
    [InlineData("Kafka:Kvalitetsportalen:LogExceptioninvocationsTopic")]
    [InlineData("Kafka:Kvalitetsportalen:LogSuccessfulinvocationsLowPriTopic")]
    [InlineData("Kafka:Kvalitetsportalen:LogExceptioninvocationsLowPriTopic")]
    [InlineData("Vault:Kvalitetsportalen:SasUri")]
    public void AddKvalitetsportalenServices_Unpacks_Configuration(string configKey)
    {
        // Arrange
        var basicMocks = new BasicMocks();
        var underTest = CreateUnderTest();

        // Act
        underTest.AddKvalitetsportalenServices(basicMocks.Configuration, true, basicMocks.HashiVaultWrapper);

        // Assert
        A.CallTo(() => basicMocks.Configuration[configKey]).MustHaveHappenedOnceExactly();
    }

    [Theory]
    [InlineData("Vault:Kvalitetsportalen:SasUri")]
    public void AddKvalitetsportalenServices_ForwardsTo_Vault(string configKey)
    {
        // Arrange
        var expected = "The expected vault path";
        var basicMocks = new BasicMocks();
        A.CallTo(() => basicMocks.Configuration[configKey]).Returns(expected);
        var underTest = CreateUnderTest();

        // Act
        underTest.AddKvalitetsportalenServices(basicMocks.Configuration, true, basicMocks.HashiVaultWrapper);

        // Assert
        A.CallTo(() => basicMocks.HashiVaultWrapper.GetGenericSecret(expected, false)).MustHaveHappenedOnceExactly();
    }

    private static IServiceCollection CreateUnderTest()
    {
        return new ServiceCollection();
    }

    private class BasicMocks
    {
        public readonly IConfiguration Configuration;
        public readonly IHashiVaultWrapper HashiVaultWrapper;

        public BasicMocks()
        {
            Configuration = A.Fake<IConfiguration>();
            var sasUriPath = "SasUriPath";
            A.CallTo(() =>
                    Configuration["Vault:Kvalitetsportalen:SasUri"])
                .Returns(sasUriPath);

            HashiVaultWrapper = A.Fake<IHashiVaultWrapper>();
            A.CallTo(() =>
                    HashiVaultWrapper.GetGenericSecret(String.Empty, false))
                .Returns(Faker.Pokemon.Name());
            A.CallTo(() =>
                    HashiVaultWrapper.GetGenericSecret(sasUriPath, false))
                .Returns("http://www.tulleadresse.com/");
        }
    }
}