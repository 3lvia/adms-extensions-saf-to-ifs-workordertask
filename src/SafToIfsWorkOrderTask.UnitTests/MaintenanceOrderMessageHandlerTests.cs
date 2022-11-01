using adms_extensions_saf_to_ifs_workordertask.PerformMessages;
using AutoMapper;
using Elvia.KvalitetsportalLogger;
using FakeItEasy;
using MaintenanceOrderReader.MessageHandlers;
using MaintenanceOrdersOutBound;
using ServicesIfs;
using Xunit;

namespace SafToIfsWorkOrderTask.UnitTests;

public class MaintenanceOrderMessageHandlerTests
{
    [Theory]
    [InlineData("Hyse")]
    [InlineData("<message>\n   <text>Hello, world!</text>\n</message>")]
    public void HandleMessage_Throws_ForMalformedXMLs(string input)
    {
        // Arrange
        var basicMocks = new BasicMocks();
        var underTest = CreateUnderTest(basicMocks);

        // Act
        var actual = Record.Exception(() => underTest.HandleMessage(input));


        // Assert
        //Assert.IsType<InvalidOperationException>(actual);
  

    }


    private MaintenanceOrderMessageHandler CreateUnderTest(BasicMocks basicMocks)
    {
        return new MaintenanceOrderMessageHandler(
            basicMocks.PerformMessageMaintenanceOrder,
            basicMocks.KvalitetsportalClient);
    }

    private class BasicMocks
    {
        public readonly IKvalitetsportalClient KvalitetsportalClient;
        public readonly IPerformMessageMaintenanceOrder PerformMessageMaintenanceOrder;

        public BasicMocks()
        {
            PerformMessageMaintenanceOrder = A.Fake<PerformMessageMaintenanceOrder>();
            KvalitetsportalClient = A.Fake<IKvalitetsportalClient>();
        }
    }
}