using FakeItEasy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SafToIfsWorkOrderTask.ServiceCollectionExtensions;
using Xunit;

namespace SafToIfsWorkOrderTask.UnitTests.ServiceCollectionExtensions;

public class ActiveMQCollectionExtensionsTests
{
    //[Fact]
    //public void AddActiveMQServices_Contains_ExpectedNumberOfServices()
    //{
    //    // Arrange
    //    var expected = 23;
    //    var basicMocks = new BasicMocks();
    //    var underTest = CreateUnderTest();

    //    // Act
    //    var actual = underTest.AddActiveMQServices(basicMocks.Configuration, true);

    //    // Assert
    //    Assert.Equal(expected, actual.Count);
    //}

    //[Theory]
    //[InlineData(typeof(IConfigActiveMQListeners))]
    //public void AddActiveMQServices_Contains_ExpectedService(Type type)
    //{
    //    // Arrange
    //    var basicMocks = new BasicMocks();
    //    var underTest = CreateUnderTest();

    //    // Act
    //    var actual = underTest.AddActiveMQServices(basicMocks.Configuration, true);

    //    // Assert
    //    Assert.Equal(1, actual.Count(i => i.ServiceType == type));
    //}

    //[Theory]
    //[InlineData(typeof(CustomerNotificationMessageHandler))]
    //[InlineData(typeof(ChangeContractorMessageHandler))]
    //[InlineData(typeof(ChangeStaffMemberMessageHandler))]
    //[InlineData(typeof(ChangeKilePrefsMessageHandler))]
    //[InlineData(typeof(ChangeCustomersMessageHandler))]
    //[InlineData(typeof(ChangeInstallationMessageHandler))]
    //[InlineData(typeof(EnergizationStatusMessageHandler))]
    //[InlineData(typeof(SwitchingPlansMessageHandler))]
    //[InlineData(typeof(MaintenanceOrdersMessageHandler))]
    //[InlineData(typeof(IFSWorkOrderMessageHandler))]
    //[InlineData(typeof(WorkOrderMessageHandler))]
    //public void AddActiveMQServices_Contains_ExpectedHostedServiceImplementation(Type type)
    //{
    //    // Arrange
    //    var basicMocks = new BasicMocks();
    //    var underTest = CreateUnderTest();

    //    // Act
    //    var actual = underTest.AddActiveMQServices(basicMocks.Configuration, true);

    //    // Assert
    //    Assert.Equal(1, actual.Count(i => i.ImplementationType == type));
    //}

    //private static IServiceCollection CreateUnderTest()
    //{
    //    return new ServiceCollection();
    //}

    //private class BasicMocks
    //{
    //    public readonly IConfiguration Configuration;

    //    public BasicMocks()
    //    {
    //        Configuration = A.Fake<IConfiguration>();
    //    }
    //}
}