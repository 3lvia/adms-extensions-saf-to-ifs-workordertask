using Microsoft.Extensions.DependencyInjection;
using SafToIfsWorkOrderTask.ServiceCollectionExtensions;
using ServicesIfs;
using Xunit;

namespace SafToIfsWorkOrderTask.UnitTests.ServiceCollectionExtensions;

public class AuthCollectionExtensionsTests
{
    [Fact]
    public void AddAuthServices_Contains_ExpectedNumberOfServices()
    {
        // Arrange
        var expected = 3;
        var underTest = CreateUnderTest();

        // Act
        var actual = underTest.AddAuthServices();


        // Assert
        Assert.Equal(expected, actual.Count);
    }

    [Theory]
    [InlineData(typeof(IClientCredentialsConfiguration))]
    [InlineData(typeof(IAccessTokenService))]
    public void AddAuthServices_Contains_ExpectedService(Type type)
    {
        // Arrange
        var underTest = CreateUnderTest();

        // Act
        var actual = underTest.AddAuthServices();

        // Assert
        Assert.Equal(1, actual.Count(i => i.ServiceType == type));
    }

    private static IServiceCollection CreateUnderTest()
    {
        return new ServiceCollection();
    }
}