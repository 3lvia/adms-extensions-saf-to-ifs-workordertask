using MaintenanceOrdersInBoundDomain;
using Xunit;
namespace SafToSesam.UnitTests.MaintenanceObjects;

public class MaintenanceOrdersDtoCrewNamesNameTypeNameTypeAuthorityDtoTests
{

   [Fact]
   public void CrewNamesNameTypeNameTypeAuthorityDto_SetValue_description()
   {
      // Arrange
      var underTest = CreateUnderTest();

      // Act
      var actual = underTest.description;

      // Assert
      Assert.Equal("text_1", actual);
   }

   [Fact]
   public void CrewNamesNameTypeNameTypeAuthorityDto_SetValue_name()
   {
      // Arrange
      var underTest = CreateUnderTest();

      // Act
      var actual = underTest.name;

      // Assert
      Assert.Equal("text_2", actual);
   }

   private static CrewNamesNameTypeNameTypeAuthorityDto CreateUnderTest()
   {
      return new CrewNamesNameTypeNameTypeAuthorityDto()
      {
         description = "text_1",
         name = "text_2",
      };
   }

}
