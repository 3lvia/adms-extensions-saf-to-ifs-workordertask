using MaintenanceOrdersInBoundDomain;
using Xunit;
namespace SafToSesam.UnitTests.MaintenanceObjects;

public class MaintenanceOrdersDtoWorkNamesDtoTests
{

   [Fact]
   public void WorkNamesDto_SetValue_name()
   {
      // Arrange
      var underTest = CreateUnderTest();

      // Act
      var actual = underTest.name;

      // Assert
      Assert.Equal("text_1", actual);
   }

   private static WorkNamesDto CreateUnderTest()
   {
      return new WorkNamesDto()
      {
         name = "text_1",
      };
   }

}
