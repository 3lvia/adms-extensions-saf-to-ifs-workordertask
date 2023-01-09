using MaintenanceOrdersInBoundDomain;
using Xunit;
namespace SafToSesam.UnitTests.MaintenanceObjects;

public class MaintenanceOrdersDtoWorkPriorityDtoTests
{

   [Fact]
   public void WorkPriorityDto_SetValue_rank()
   {
      // Arrange
      var underTest = CreateUnderTest();

      // Act
      var actual = underTest.rank;

      // Assert
      Assert.Equal("text_1", actual);
   }

   private static WorkPriorityDto CreateUnderTest()
   {
      return new WorkPriorityDto()
      {
         rank = "text_1",
      };
   }

}
