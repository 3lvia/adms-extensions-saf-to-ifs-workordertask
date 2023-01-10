using FakeItEasy;
using MaintenanceOrdersInBoundDomain;
using Xunit;
namespace SafToSesam.UnitTests.MaintenanceObjects;

public class MaintenanceOrdersDtoEquipmentDtoTests
{

   [Fact]
   public void EquipmentDto_SetValue_mRID()
   {
      // Arrange
      var underTest = CreateUnderTest();

      // Act
      var actual = underTest.mRID;

      // Assert
      Assert.Equal("text_1", actual);
   }

   [Fact]
   public void EquipmentDto_SetValue_type()
   {
      // Arrange
      var underTest = CreateUnderTest();

      // Act
      var actual = underTest.type;

      // Assert
      Assert.Equal("text_2", actual);
   }

   [Fact]
   public void EquipmentDto_SetValue_B1TEXT()
   {
      // Arrange
      var underTest = CreateUnderTest();

      // Act
      var actual = underTest.B1TEXT;

      // Assert
      Assert.Equal("text_3", actual);
   }

   [Fact]
   public void EquipmentDto_SetValue_B2TEXT()
   {
      // Arrange
      var underTest = CreateUnderTest();

      // Act
      var actual = underTest.B2TEXT;

      // Assert
      Assert.Equal("text_4", actual);
   }

   [Fact]
   public void EquipmentDto_SetValue_B3TEXT()
   {
      // Arrange
      var underTest = CreateUnderTest();

      // Act
      var actual = underTest.B3TEXT;

      // Assert
      Assert.Equal("text_5", actual);
   }

   [Fact]
   public void EquipmentDto_SetValue_ELTEXT()
   {
      // Arrange
      var underTest = CreateUnderTest();

      // Act
      var actual = underTest.ELTEXT;

      // Assert
      Assert.Equal("text_6", actual);
   }

   [Fact]
   public void EquipmentDto_SetValue_Feedername()
   {
      // Arrange
      var underTest = CreateUnderTest();

      // Act
      var actual = underTest.Feedername;

      // Assert
      Assert.Equal("text_7", actual);
   }

   [Fact]
   public void EquipmentDto_SetValue_FeederLV()
   {
      // Arrange
      var underTest = CreateUnderTest();

      // Act
      var actual = underTest.FeederLV;

      // Assert
      Assert.Equal("text_8", actual);
   }

   [Fact]
   public void EquipmentDto_SetValue_VoltageLevelNum()
   {
      // Arrange
      var underTest = CreateUnderTest();

      // Act
      var actual = underTest.VoltageLevelNum;

      // Assert
      Assert.Equal("text_9", actual);
   }

   private static EquipmentDto CreateUnderTest()
   {
      return new EquipmentDto()
      {
         mRID = "text_1",
         Names = new List<EquipmentNamesDto>() { A.Fake<EquipmentNamesDto>() }.ToArray(),
         type = "text_2",
         B1TEXT = "text_3",
         B2TEXT = "text_4",
         B3TEXT = "text_5",
         ELTEXT = "text_6",
         Feedername = "text_7",
         FeederLV = "text_8",
         VoltageLevelNum = "text_9",
      };
   }

}
