using MaintenanceOrdersInBoundDomain;
using Xunit;
namespace SafToSesam.UnitTests.MaintenanceObjects;

public class MaintenanceOrdersDtoWorkTimeScheduleScheduleIntervalDtoTests
{

   [Fact]
   public void WorkTimeScheduleScheduleIntervalDto_SetValue_end()
   {
      // Arrange
      var underTest = CreateUnderTest();

      // Act
      var actual = underTest.end;

      // Assert
      Assert.Equal(new DateTime(2020, 1, 1, 1, 1, 1), actual);
   }

   [Fact]
   public void WorkTimeScheduleScheduleIntervalDto_SetValue_endSpecified()
   {
      // Arrange
      var underTest = CreateUnderTest();

      // Act
      var actual = underTest.endSpecified;

      // Assert
      Assert.Equal(true, actual);
   }

   [Fact]
   public void WorkTimeScheduleScheduleIntervalDto_SetValue_start()
   {
      // Arrange
      var underTest = CreateUnderTest();

      // Act
      var actual = underTest.start;

      // Assert
      Assert.Equal(new DateTime(2020, 1, 1, 1, 1, 2), actual);
   }

   [Fact]
   public void WorkTimeScheduleScheduleIntervalDto_SetValue_startSpecified()
   {
      // Arrange
      var underTest = CreateUnderTest();

      // Act
      var actual = underTest.startSpecified;

      // Assert
      Assert.Equal(true, actual);
   }

   private static WorkTimeScheduleScheduleIntervalDto CreateUnderTest()
   {
      return new WorkTimeScheduleScheduleIntervalDto()
      {
         end = new DateTime(2020, 1, 1, 1, 1, 1),
         endSpecified = true,
         start = new DateTime(2020, 1, 1, 1, 1, 2),
         startSpecified = true,
      };
   }

}
