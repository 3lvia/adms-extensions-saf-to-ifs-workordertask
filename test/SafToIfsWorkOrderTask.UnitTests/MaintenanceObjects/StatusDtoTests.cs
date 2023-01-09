using MaintenanceOrdersInBoundDomain;
using Xunit;
namespace SafToSesam.UnitTests.MaintenanceObjects;

public class MaintenanceOrdersDtoStatusDtoTests
{

   [Fact]
   public void StatusDto_SetValue_dateTime()
   {
      // Arrange
      var underTest = CreateUnderTest();

      // Act
      var actual = underTest.dateTime;

      // Assert
      Assert.Equal(new DateTime(2020, 1, 1, 1, 1, 1), actual);
   }

   [Fact]
   public void StatusDto_SetValue_value()
   {
      // Arrange
      var underTest = CreateUnderTest();

      // Act
      var actual = underTest.value;

      // Assert
      Assert.Equal("text_2", actual);
   }

   private static StatusDto CreateUnderTest()
   {
      return new StatusDto()
      {
         dateTime = new DateTime(2020, 1, 1, 1, 1, 1),
         value = "text_2",
      };
   }

}
