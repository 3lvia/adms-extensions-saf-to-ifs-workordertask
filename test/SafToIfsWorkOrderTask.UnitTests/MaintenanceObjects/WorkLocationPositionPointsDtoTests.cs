using MaintenanceOrdersInBoundDomain;
using Xunit;
namespace SafToSesam.UnitTests.MaintenanceObjects;

public class MaintenanceOrdersDtoWorkLocationPositionPointsDtoTests
{

   [Fact]
   public void WorkLocationPositionPointsDto_SetValue_sequenceNumber()
   {
      // Arrange
      var underTest = CreateUnderTest();

      // Act
      var actual = underTest.sequenceNumber;

      // Assert
      Assert.Equal("text_1", actual);
   }

   [Fact]
   public void WorkLocationPositionPointsDto_SetValue_xPosition()
   {
      // Arrange
      var underTest = CreateUnderTest();

      // Act
      var actual = underTest.xPosition;

      // Assert
      Assert.Equal("text_2", actual);
   }

   [Fact]
   public void WorkLocationPositionPointsDto_SetValue_yPosition()
   {
      // Arrange
      var underTest = CreateUnderTest();

      // Act
      var actual = underTest.yPosition;

      // Assert
      Assert.Equal("text_3", actual);
   }

   [Fact]
   public void WorkLocationPositionPointsDto_SetValue_zPosition()
   {
      // Arrange
      var underTest = CreateUnderTest();

      // Act
      var actual = underTest.zPosition;

      // Assert
      Assert.Equal("text_4", actual);
   }

   private static WorkLocationPositionPointsDto CreateUnderTest()
   {
      return new WorkLocationPositionPointsDto()
      {
         sequenceNumber = "text_1",
         xPosition = "text_2",
         yPosition = "text_3",
         zPosition = "text_4",
      };
   }

}
