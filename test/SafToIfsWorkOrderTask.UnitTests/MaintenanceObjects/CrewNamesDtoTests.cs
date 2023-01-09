using FakeItEasy;
using MaintenanceOrdersInBoundDomain;
using Xunit;
namespace SafToSesam.UnitTests.MaintenanceObjects;

public class MaintenanceOrdersDtoCrewNamesDtoTests
{

   [Fact]
   public void CrewNamesDto_SetValue_name()
   {
      // Arrange
      var underTest = CreateUnderTest();

      // Act
      var actual = underTest.name;

      // Assert
      Assert.Equal("text_1", actual);
   }

   private static CrewNamesDto CreateUnderTest()
   {
      return new CrewNamesDto()
      {
         name = "text_1",
         NameType = A.Dummy<CrewNamesNameTypeDto>(),
      };
   }

}
