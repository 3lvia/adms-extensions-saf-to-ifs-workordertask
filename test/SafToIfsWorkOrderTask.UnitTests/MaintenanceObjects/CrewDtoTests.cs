using FakeItEasy;
using MaintenanceOrdersInBoundDomain;
using Xunit;
namespace SafToSesam.UnitTests.MaintenanceObjects;

public class MaintenanceOrdersDtoCrewDtoTests
{

   [Fact]
   public void CrewDto_SetValue_mRID()
   {
      // Arrange
      var underTest = CreateUnderTest();

      // Act
      var actual = underTest.mRID;

      // Assert
      Assert.Equal("text_1", actual);
   }

   [Fact]
   public void CrewDto_SetValue_lastModifiedDateTime()
   {
      // Arrange
      var underTest = CreateUnderTest();

      // Act
      var actual = underTest.lastModifiedDateTime;

      // Assert
      Assert.Equal(new DateTime(2020, 1, 1, 1, 1, 2), actual);
   }

   [Fact]
   public void CrewDto_SetValue_lastModifiedDateTimeSpecified()
   {
      // Arrange
      var underTest = CreateUnderTest();

      // Act
      var actual = underTest.lastModifiedDateTimeSpecified;

      // Assert
      Assert.Equal(true, actual);
   }

   private static CrewDto CreateUnderTest()
   {
      return new CrewDto()
      {
         mRID = "text_1",
         lastModifiedDateTime = new DateTime(2020, 1, 1, 1, 1, 2),
         lastModifiedDateTimeSpecified = true,
         status = A.Dummy<StatusDto>(),
         CrewMembers = new List<CrewMemberDto>() { A.Fake<CrewMemberDto>() }.ToArray(),
         Names = new List<CrewNamesDto>() { A.Fake<CrewNamesDto>() }.ToArray(),
         WorkAssets = new List<WorkAssetDto>() { A.Fake<WorkAssetDto>() }.ToArray(),
      };
   }

}
