using FakeItEasy;
using MaintenanceOrdersInBoundDomain;
using Xunit;
namespace SafToSesam.UnitTests.MaintenanceObjects;

public class MaintenanceOrdersDtoWorkAssetDtoTests
{

   [Fact]
   public void WorkAssetDto_SetValue_usageKind()
   {
      // Arrange
      var underTest = CreateUnderTest();

      // Act
      var actual = underTest.usageKind;

      // Assert
      Assert.Equal("text_1", actual);
   }

   [Fact]
   public void WorkAssetDto_SetValue_mRID()
   {
      // Arrange
      var underTest = CreateUnderTest();

      // Act
      var actual = underTest.mRID;

      // Assert
      Assert.Equal("text_2", actual);
   }

   [Fact]
   public void WorkAssetDto_SetValue_lastModifiedDateTime()
   {
      // Arrange
      var underTest = CreateUnderTest();

      // Act
      var actual = underTest.lastModifiedDateTime;

      // Assert
      Assert.Equal(new DateTime(2020, 1, 1, 1, 1, 3), actual);
   }

   [Fact]
   public void WorkAssetDto_SetValue_lastModifiedDateTimeSpecified()
   {
      // Arrange
      var underTest = CreateUnderTest();

      // Act
      var actual = underTest.lastModifiedDateTimeSpecified;

      // Assert
      Assert.Equal(true, actual);
   }

   [Fact]
   public void WorkAssetDto_SetValue_critical()
   {
      // Arrange
      var underTest = CreateUnderTest();

      // Act
      var actual = underTest.critical;

      // Assert
      Assert.Equal(true, actual);
   }

   [Fact]
   public void WorkAssetDto_SetValue_utcNumber()
   {
      // Arrange
      var underTest = CreateUnderTest();

      // Act
      var actual = underTest.utcNumber;

      // Assert
      Assert.Equal("text_4", actual);
   }

   [Fact]
   public void WorkAssetDto_SetValue_type()
   {
      // Arrange
      var underTest = CreateUnderTest();

      // Act
      var actual = underTest.type;

      // Assert
      Assert.Equal("text_5", actual);
   }

   private static WorkAssetDto CreateUnderTest()
   {
      return new WorkAssetDto()
      {
         usageKind = "text_1",
         mRID = "text_2",
         lastModifiedDateTime = new DateTime(2020, 1, 1, 1, 1, 3),
         lastModifiedDateTimeSpecified = true,
         critical = true,
         utcNumber = "text_4",
         status = A.Dummy<StatusDto>(),
         type = "text_5",
         Location = A.Dummy<WorkLocationDto>(),
         Names = new List<AssetNamesDto>() { A.Fake<AssetNamesDto>() }.ToArray(),
      };
   }

}
