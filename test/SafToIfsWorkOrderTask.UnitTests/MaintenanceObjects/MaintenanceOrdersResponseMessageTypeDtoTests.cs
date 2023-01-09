using FakeItEasy;
using MaintenanceOrdersInBoundDomain;
using Xunit;
namespace SafToSesam.UnitTests.MaintenanceObjects;

public class MaintenanceOrdersDtoMaintenanceOrdersResponseMessageTypeDtoTests
{

   [Fact]
   public void MaintenanceOrdersResponseMessageTypeDto_SetValue_CorrelationId()
   {
      // Arrange
      var underTest = CreateUnderTest();

      // Act
      var actual = underTest.CorrelationId;

      // Assert
      Assert.Equal("text_1", actual);
   }

   private static MaintenanceOrdersResponseMessageTypeDto CreateUnderTest()
   {
      return new MaintenanceOrdersResponseMessageTypeDto()
      {
         Header = A.Dummy<HeaderType1Dto>(),
         CorrelationId = "text_1",
         Payload = new List<DetailedFaultResponseTypeDto>() { A.Fake<DetailedFaultResponseTypeDto>() }.ToArray(),
      };
   }

}
