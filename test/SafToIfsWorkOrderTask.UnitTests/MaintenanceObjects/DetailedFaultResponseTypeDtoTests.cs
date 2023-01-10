using FakeItEasy;
using MaintenanceOrdersInBoundDomain;
using Xunit;
namespace SafToSesam.UnitTests.MaintenanceObjects;

public class MaintenanceOrdersDtoDetailedFaultResponseTypeDtoTests
{

   [Fact]
   public void DetailedFaultResponseTypeDto_SetValue_mRID()
   {
      // Arrange
      var underTest = CreateUnderTest();

      // Act
      var actual = underTest.mRID;

      // Assert
      Assert.Equal("text_1", actual);
   }

   [Fact]
   public void DetailedFaultResponseTypeDto_SetValue_success()
   {
      // Arrange
      var underTest = CreateUnderTest();

      // Act
      var actual = underTest.success;

      // Assert
      Assert.Equal(true, actual);
   }

   private static DetailedFaultResponseTypeDto CreateUnderTest()
   {
      return new DetailedFaultResponseTypeDto()
      {
         mRID = "text_1",
         success = true,
         StandardFault = new List<StandardFaultDto>() { A.Fake<StandardFaultDto>() }.ToArray(),
      };
   }

}
