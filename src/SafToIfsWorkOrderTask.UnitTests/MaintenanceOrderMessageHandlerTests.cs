//using AutoMapper;
//using Elvia.KvalitetsportalLogger;
//using FakeItEasy;
//using MaintenanceOrderReader.MessageHandlers;
//using MaintenanceOrdersOutBound;
//using ServicesIfs;
//using Xunit;

//namespace SafToIfsWorkOrderTask.UnitTests;

//public class MaintenanceOrderMessageHandlerTests
//{
//    [Theory]
//    [InlineData("Hyse")]
//    [InlineData("<message>\n   <text>Hello, world!</text>\n</message>")]
//    public void HandleMessage_Throws_ForMalformedXMLs(string input)
//    {
//        // Arrange
//        var basicMocks = new BasicMocks();
//        var underTest = CreateUnderTest(basicMocks);

//        // Act
//        var actual = Record.Exception(() => underTest.HandleMessage(input));

//        // Assert
//        Assert.IsType<InvalidOperationException>(actual);
//    }

//    private MaintenanceOrderMessageHandler CreateUnderTest(BasicMocks basicMocks)
//    {
//        return new MaintenanceOrderMessageHandler(
//            basicMocks.IfsWorkOrder,
//            basicMocks.Mapper,
//            basicMocks.Soap,
//            basicMocks.KvalitetsportalClient);
//    }

//    private class BasicMocks
//    {
//        public readonly IIfsWorkOrder IfsWorkOrder;
//        public readonly IMapper Mapper;
//        public readonly IMaintenanceOrders_Port Soap;
//        public readonly IKvalitetsportalClient KvalitetsportalClient;

//        public BasicMocks()
//        {
//            IfsWorkOrder = A.Fake<IIfsWorkOrder>();
//            Mapper = A.Fake<IMapper>();
//            Soap = A.Fake<IMaintenanceOrders_Port>();
//            KvalitetsportalClient = A.Fake<IKvalitetsportalClient>();
//        }
//    }
//}