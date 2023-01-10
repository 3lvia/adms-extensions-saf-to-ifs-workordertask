using MaintenanceOrdersInBoundDomain;
using Xunit;
namespace SafToSesam.UnitTests.MaintenanceObjects;

public class MaintenanceOrdersDtoWorkLocationCoordinateSystemDtoTests
{

   [Fact]
   public void WorkLocationCoordinateSystemDto_SetValue_crsUrn()
   {
      // Arrange
      var underTest = CreateUnderTest();

      // Act
      var actual = underTest.crsUrn;

      // Assert
      Assert.Equal("text_1", actual);
   }

   private static WorkLocationCoordinateSystemDto CreateUnderTest()
   {
      return new WorkLocationCoordinateSystemDto()
      {
         crsUrn = "text_1",
      };
   }

}
