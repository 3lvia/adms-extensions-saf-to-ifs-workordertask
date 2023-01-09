using MaintenanceOrdersInBoundDomain;
using Xunit;
namespace SafToSesam.UnitTests.MaintenanceObjects;

public class MaintenanceOrdersDtoOrganisationDtoTests
{

   [Fact]
   public void OrganisationDto_SetValue_mRID()
   {
      // Arrange
      var underTest = CreateUnderTest();

      // Act
      var actual = underTest.mRID;

      // Assert
      Assert.Equal("text_1", actual);
   }

   private static OrganisationDto CreateUnderTest()
   {
      return new OrganisationDto()
      {
         mRID = "text_1",
      };
   }

}
