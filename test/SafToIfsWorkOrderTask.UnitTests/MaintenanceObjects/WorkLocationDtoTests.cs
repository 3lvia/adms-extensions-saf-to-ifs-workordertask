using FakeItEasy;
using MaintenanceOrdersInBoundDomain;
using Xunit;
namespace SafToSesam.UnitTests.MaintenanceObjects;

public class MaintenanceOrdersDtoWorkLocationDtoTests
{

   [Fact]
   public void WorkLocationDto_SetValue_mRID()
   {
      // Arrange
      var underTest = CreateUnderTest();

      // Act
      var actual = underTest.mRID;

      // Assert
      Assert.Equal("text_1", actual);
   }

   private static WorkLocationDto CreateUnderTest()
   {
      return new WorkLocationDto()
      {
         mRID = "text_1",
         CoordinateSystem = A.Dummy<WorkLocationCoordinateSystemDto>(),
         PositionPoints = new List<WorkLocationPositionPointsDto>() { A.Fake<WorkLocationPositionPointsDto>() }.ToArray(),
      };
   }

}
