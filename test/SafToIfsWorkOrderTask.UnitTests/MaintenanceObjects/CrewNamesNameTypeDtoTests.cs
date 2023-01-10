using FakeItEasy;
using MaintenanceOrdersInBoundDomain;
using Xunit;
namespace SafToSesam.UnitTests.MaintenanceObjects;

public class MaintenanceOrdersDtoCrewNamesNameTypeDtoTests
{

   [Fact]
   public void CrewNamesNameTypeDto_SetValue_description()
   {
      // Arrange
      var underTest = CreateUnderTest();

      // Act
      var actual = underTest.description;

      // Assert
      Assert.Equal("text_1", actual);
   }

   [Fact]
   public void CrewNamesNameTypeDto_SetValue_name()
   {
      // Arrange
      var underTest = CreateUnderTest();

      // Act
      var actual = underTest.name;

      // Assert
      Assert.Equal("text_2", actual);
   }

   private static CrewNamesNameTypeDto CreateUnderTest()
   {
      return new CrewNamesNameTypeDto()
      {
         description = "text_1",
         name = "text_2",
         NameTypeAuthority = A.Dummy<CrewNamesNameTypeNameTypeAuthorityDto>(),
      };
   }

}
