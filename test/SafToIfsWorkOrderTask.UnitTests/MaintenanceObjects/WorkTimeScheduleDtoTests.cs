using FakeItEasy;
using MaintenanceOrdersInBoundDomain;
using Xunit;
namespace SafToSesam.UnitTests.MaintenanceObjects;

public class MaintenanceOrdersDtoWorkTimeScheduleDtoTests
{

   [Fact]
   public void WorkTimeScheduleDto_SetValue_kind()
   {
      // Arrange
      var underTest = CreateUnderTest();

      // Act
      var actual = underTest.kind;

      // Assert
      Assert.Equal("text_1", actual);
   }

   private static WorkTimeScheduleDto CreateUnderTest()
   {
      return new WorkTimeScheduleDto()
      {
         kind = "text_1",
         scheduleInterval = A.Dummy<WorkTimeScheduleScheduleIntervalDto>(),
      };
   }

}
