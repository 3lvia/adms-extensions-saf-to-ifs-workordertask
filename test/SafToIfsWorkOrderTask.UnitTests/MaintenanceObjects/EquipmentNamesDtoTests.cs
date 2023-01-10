using MaintenanceOrdersInBoundDomain;
using Xunit;
namespace SafToSesam.UnitTests.MaintenanceObjects;

public class MaintenanceOrdersDtoEquipmentNamesDtoTests
{

   [Fact]
   public void EquipmentNamesDto_SetValue_name()
   {
      // Arrange
      var underTest = CreateUnderTest();

      // Act
      var actual = underTest.name;

      // Assert
      Assert.Equal("text_1", actual);
   }

   private static EquipmentNamesDto CreateUnderTest()
   {
      return new EquipmentNamesDto()
      {
         name = "text_1",
      };
   }

}
