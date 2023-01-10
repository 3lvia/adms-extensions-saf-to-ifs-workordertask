using FakeItEasy;
using MaintenanceOrdersInBoundDomain;
using Xunit;
namespace SafToSesam.UnitTests.MaintenanceObjects;

public class MaintenanceOrdersDtoAssetDtoTests
{

   [Fact]
   public void AssetDto_SetValue_mRID()
   {
      // Arrange
      var underTest = CreateUnderTest();

      // Act
      var actual = underTest.mRID;

      // Assert
      Assert.Equal("text_1", actual);
   }

   [Fact]
   public void AssetDto_SetValue_lastModifiedDateTime()
   {
      // Arrange
      var underTest = CreateUnderTest();

      // Act
      var actual = underTest.lastModifiedDateTime;

      // Assert
      Assert.Equal(new DateTime(2020, 1, 1, 1, 1, 2), actual);
   }

   [Fact]
   public void AssetDto_SetValue_lastModifiedDateTimeSpecified()
   {
      // Arrange
      var underTest = CreateUnderTest();

      // Act
      var actual = underTest.lastModifiedDateTimeSpecified;

      // Assert
      Assert.Equal(true, actual);
   }

   [Fact]
   public void AssetDto_SetValue_critical()
   {
      // Arrange
      var underTest = CreateUnderTest();

      // Act
      var actual = underTest.critical;

      // Assert
      Assert.Equal(true, actual);
   }

   [Fact]
   public void AssetDto_SetValue_utcNumber()
   {
      // Arrange
      var underTest = CreateUnderTest();

      // Act
      var actual = underTest.utcNumber;

      // Assert
      Assert.Equal("text_3", actual);
   }

   [Fact]
   public void AssetDto_SetValue_type()
   {
      // Arrange
      var underTest = CreateUnderTest();

      // Act
      var actual = underTest.type;

      // Assert
      Assert.Equal("text_4", actual);
   }

   private static AssetDto CreateUnderTest()
   {
      return new AssetDto()
      {
         mRID = "text_1",
         lastModifiedDateTime = new DateTime(2020, 1, 1, 1, 1, 2),
         lastModifiedDateTimeSpecified = true,
         critical = true,
         utcNumber = "text_3",
         status = A.Dummy<StatusDto>(),
         type = "text_4",
         Location = A.Dummy<WorkLocationDto>(),
         Names = new List<AssetNamesDto>() { A.Fake<AssetNamesDto>() }.ToArray(),
      };
   }

}
