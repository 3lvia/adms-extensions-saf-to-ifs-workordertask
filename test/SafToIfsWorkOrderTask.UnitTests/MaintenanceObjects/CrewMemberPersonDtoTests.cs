using FakeItEasy;
using MaintenanceOrdersInBoundDomain;
using Xunit;
namespace SafToSesam.UnitTests.MaintenanceObjects;

public class MaintenanceOrdersDtoCrewMemberPersonDtoTests
{

   [Fact]
   public void CrewMemberPersonDto_SetValue_mRID()
   {
      // Arrange
      var underTest = CreateUnderTest();

      // Act
      var actual = underTest.mRID;

      // Assert
      Assert.Equal("text_1", actual);
   }

   [Fact]
   public void CrewMemberPersonDto_SetValue_lastModifiedDateTime()
   {
      // Arrange
      var underTest = CreateUnderTest();

      // Act
      var actual = underTest.lastModifiedDateTime;

      // Assert
      Assert.Equal(new DateTime(2020, 1, 1, 1, 1, 2), actual);
   }

   [Fact]
   public void CrewMemberPersonDto_SetValue_lastModifiedDateTimeSpecified()
   {
      // Arrange
      var underTest = CreateUnderTest();

      // Act
      var actual = underTest.lastModifiedDateTimeSpecified;

      // Assert
      Assert.Equal(true, actual);
   }

   [Fact]
   public void CrewMemberPersonDto_SetValue_firstName()
   {
      // Arrange
      var underTest = CreateUnderTest();

      // Act
      var actual = underTest.firstName;

      // Assert
      Assert.Equal("text_3", actual);
   }

   [Fact]
   public void CrewMemberPersonDto_SetValue_lastName()
   {
      // Arrange
      var underTest = CreateUnderTest();

      // Act
      var actual = underTest.lastName;

      // Assert
      Assert.Equal("text_4", actual);
   }

   [Fact]
   public void CrewMemberPersonDto_SetValue_prefix()
   {
      // Arrange
      var underTest = CreateUnderTest();

      // Act
      var actual = underTest.prefix;

      // Assert
      Assert.Equal("text_5", actual);
   }

   [Fact]
   public void CrewMemberPersonDto_SetValue_employeeId()
   {
      // Arrange
      var underTest = CreateUnderTest();

      // Act
      var actual = underTest.employeeId;

      // Assert
      Assert.Equal("text_6", actual);
   }

   private static CrewMemberPersonDto CreateUnderTest()
   {
      return new CrewMemberPersonDto()
      {
         mRID = "text_1",
         lastModifiedDateTime = new DateTime(2020, 1, 1, 1, 1, 2),
         lastModifiedDateTimeSpecified = true,
         firstName = "text_3",
         lastName = "text_4",
         prefix = "text_5",
         employeeId = "text_6",
         mobilePhone = A.Dummy<TelephoneNumberDto>(),
         electronicAddress = A.Dummy<ElectronicAddressDto>(),
      };
   }

}
