using MaintenanceOrdersInBoundDomain;
using Xunit;
namespace SafToSesam.UnitTests.MaintenanceObjects;

public class MaintenanceOrdersDtoWorkTaskNamesDtoTests
{

   [Fact]
   public void WorkTaskNamesDto_SetValue_name()
   {
      // Arrange
      var underTest = CreateUnderTest();

      // Act
      var actual = underTest.name;

      // Assert
      Assert.Equal("text_1", actual);
   }

   private static WorkTaskNamesDto CreateUnderTest()
   {
      return new WorkTaskNamesDto()
      {
         name = "text_1",
      };
   }

}
