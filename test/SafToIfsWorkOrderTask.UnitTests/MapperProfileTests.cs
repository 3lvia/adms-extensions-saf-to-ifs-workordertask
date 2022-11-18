using AutoMapper;
using SafToSesamAPI;
using Xunit;

namespace SafToSesam.UnitTests;

public class MapperProfileTests
{
    [Fact]
    public void AutomapperConfigurationValidationTest()
    {
        // Arrange
        var underTest = new Mapper(new MapperConfiguration(cfg => cfg.AddProfile(new MapperProfile())));

        // Act

        // Assert
        //underTest.ConfigurationProvider.AssertConfigurationIsValid();
    }
}