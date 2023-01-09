using MaintenanceOrdersInBoundDomain;
using Xunit;
namespace SafToSesam.UnitTests.MaintenanceObjects;

public class MaintenanceOrdersDtoElectronicAddressDtoTests
{

   [Fact]
   public void ElectronicAddressDto_SetValue_email1()
   {
      // Arrange
      var underTest = CreateUnderTest();

      // Act
      var actual = underTest.email1;

      // Assert
      Assert.Equal("text_1", actual);
   }

   private static ElectronicAddressDto CreateUnderTest()
   {
      return new ElectronicAddressDto()
      {
         email1 = "text_1",
      };
   }

}
