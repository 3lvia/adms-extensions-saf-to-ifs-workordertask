using MaintenanceOrdersInBoundDomain;
using Xunit;
namespace SafToSesam.UnitTests.MaintenanceObjects;

public class MaintenanceOrdersDtoEventLog1DtoTests
{

   [Fact]
   public void EventLog1Dto_SetValue_detailedMessageText()
   {
      // Arrange
      var underTest = CreateUnderTest();

      // Act
      var actual = underTest.detailedMessageText;

      // Assert
      Assert.Equal("text_1", actual);
   }

   [Fact]
   public void EventLog1Dto_SetValue_messageText()
   {
      // Arrange
      var underTest = CreateUnderTest();

      // Act
      var actual = underTest.messageText;

      // Assert
      Assert.Equal("text_2", actual);
   }

   [Fact]
   public void EventLog1Dto_SetValue_resultCode()
   {
      // Arrange
      var underTest = CreateUnderTest();

      // Act
      var actual = underTest.resultCode;

      // Assert
      Assert.Equal("text_3", actual);
   }

   [Fact]
   public void EventLog1Dto_SetValue_severity()
   {
      // Arrange
      var underTest = CreateUnderTest();

      // Act
      var actual = underTest.severity;

      // Assert
      Assert.Equal("text_4", actual);
   }

   [Fact]
   public void EventLog1Dto_SetValue_stackTrace()
   {
      // Arrange
      var underTest = CreateUnderTest();

      // Act
      var actual = underTest.stackTrace;

      // Assert
      Assert.Equal("text_5", actual);
   }

   private static EventLog1Dto CreateUnderTest()
   {
      return new EventLog1Dto()
      {
         detailedMessageText = "text_1",
         messageText = "text_2",
         resultCode = "text_3",
         severity = "text_4",
         stackTrace = "text_5",
      };
   }

}
