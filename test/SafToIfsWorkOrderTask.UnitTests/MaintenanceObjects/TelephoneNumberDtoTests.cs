using MaintenanceOrdersInBoundDomain;
using Xunit;
namespace SafToSesam.UnitTests.MaintenanceObjects;

public class MaintenanceOrdersDtoTelephoneNumberDtoTests
{

   [Fact]
   public void TelephoneNumberDto_SetValue_localNumber()
   {
      // Arrange
      var underTest = CreateUnderTest();

      // Act
      var actual = underTest.localNumber;

      // Assert
      Assert.Equal("text_1", actual);
   }

   private static TelephoneNumberDto CreateUnderTest()
   {
      return new TelephoneNumberDto()
      {
         localNumber = "text_1",
      };
   }

}
