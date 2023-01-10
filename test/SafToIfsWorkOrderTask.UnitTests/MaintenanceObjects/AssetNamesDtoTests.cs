using MaintenanceOrdersInBoundDomain;
using Xunit;
namespace SafToSesam.UnitTests.MaintenanceObjects;

public class MaintenanceOrdersDtoAssetNamesDtoTests
{

   [Fact]
   public void AssetNamesDto_SetValue_name()
   {
      // Arrange
      var underTest = CreateUnderTest();

      // Act
      var actual = underTest.name;

      // Assert
      Assert.Equal("text_1", actual);
   }

   private static AssetNamesDto CreateUnderTest()
   {
      return new AssetNamesDto()
      {
         name = "text_1",
      };
   }

}
