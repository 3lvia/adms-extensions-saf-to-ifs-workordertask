using MaintenanceOrdersInBoundDomain;
using Xunit;
namespace SafToSesam.UnitTests.MaintenanceObjects;

public class MaintenanceOrdersDtoHeaderType1DtoTests
{

   [Fact]
   public void HeaderType1Dto_SetValue_verb()
   {
      // Arrange
      var underTest = CreateUnderTest();

      // Act
      var actual = underTest.verb;

      // Assert
      Assert.Equal("text_1", actual);
   }

   [Fact]
   public void HeaderType1Dto_SetValue_source()
   {
      // Arrange
      var underTest = CreateUnderTest();

      // Act
      var actual = underTest.source;

      // Assert
      Assert.Equal("text_2", actual);
   }

   [Fact]
   public void HeaderType1Dto_SetValue_operation()
   {
      // Arrange
      var underTest = CreateUnderTest();

      // Act
      var actual = underTest.operation;

      // Assert
      Assert.Equal("text_3", actual);
   }

   [Fact]
   public void HeaderType1Dto_SetValue_messageId()
   {
      // Arrange
      var underTest = CreateUnderTest();

      // Act
      var actual = underTest.messageId;

      // Assert
      Assert.Equal("text_4", actual);
   }

   [Fact]
   public void HeaderType1Dto_SetValue_publishedDateTime()
   {
      // Arrange
      var underTest = CreateUnderTest();

      // Act
      var actual = underTest.publishedDateTime;

      // Assert
      Assert.Equal(new DateTime(2020, 1, 1, 1, 1, 5), actual);
   }

   private static HeaderType1Dto CreateUnderTest()
   {
      return new HeaderType1Dto()
      {
         verb = "text_1",
         source = "text_2",
         operation = "text_3",
         messageId = "text_4",
         publishedDateTime = new DateTime(2020, 1, 1, 1, 1, 5),
      };
   }

}
