using FakeItEasy;
using MaintenanceOrdersInBoundDomain;
using Xunit;
namespace SafToSesam.UnitTests.MaintenanceObjects;

public class MaintenanceOrdersDtoWorkTaskDtoTests
{

   [Fact]
   public void WorkTaskDto_SetValue_mRID()
   {
      // Arrange
      var underTest = CreateUnderTest();

      // Act
      var actual = underTest.mRID;

      // Assert
      Assert.Equal("text_1", actual);
   }

   [Fact]
   public void WorkTaskDto_SetValue_lastModifiedDateTime()
   {
      // Arrange
      var underTest = CreateUnderTest();

      // Act
      var actual = underTest.lastModifiedDateTime;

      // Assert
      Assert.Equal(new DateTime(2020, 1, 1, 1, 1, 2), actual);
   }

   [Fact]
   public void WorkTaskDto_SetValue_lastModifiedDateTimeSpecified()
   {
      // Arrange
      var underTest = CreateUnderTest();

      // Act
      var actual = underTest.lastModifiedDateTimeSpecified;

      // Assert
      Assert.Equal(true, actual);
   }

   [Fact]
   public void WorkTaskDto_SetValue_creationDateTime()
   {
      // Arrange
      var underTest = CreateUnderTest();

      // Act
      var actual = underTest.creationDateTime;

      // Assert
      Assert.Equal(new DateTime(2020, 1, 1, 1, 1, 3), actual);
   }

   [Fact]
   public void WorkTaskDto_SetValue_creationDateTimeSpecified()
   {
      // Arrange
      var underTest = CreateUnderTest();

      // Act
      var actual = underTest.creationDateTimeSpecified;

      // Assert
      Assert.Equal(true, actual);
   }

   [Fact]
   public void WorkTaskDto_SetValue_crewETA()
   {
      // Arrange
      var underTest = CreateUnderTest();

      // Act
      var actual = underTest.crewETA;

      // Assert
      Assert.Equal(new DateTime(2020, 1, 1, 1, 1, 4), actual);
   }

   [Fact]
   public void WorkTaskDto_SetValue_crewETASpecified()
   {
      // Arrange
      var underTest = CreateUnderTest();

      // Act
      var actual = underTest.crewETASpecified;

      // Assert
      Assert.Equal(true, actual);
   }

   [Fact]
   public void WorkTaskDto_SetValue_crewATA()
   {
      // Arrange
      var underTest = CreateUnderTest();

      // Act
      var actual = underTest.crewATA;

      // Assert
      Assert.Equal(new DateTime(2020, 1, 1, 1, 1, 5), actual);
   }

   [Fact]
   public void WorkTaskDto_SetValue_crewATASpecified()
   {
      // Arrange
      var underTest = CreateUnderTest();

      // Act
      var actual = underTest.crewATASpecified;

      // Assert
      Assert.Equal(true, actual);
   }

   [Fact]
   public void WorkTaskDto_SetValue_crewETC()
   {
      // Arrange
      var underTest = CreateUnderTest();

      // Act
      var actual = underTest.crewETC;

      // Assert
      Assert.Equal(new DateTime(2020, 1, 1, 1, 1, 6), actual);
   }

   [Fact]
   public void WorkTaskDto_SetValue_crewETCSpecified()
   {
      // Arrange
      var underTest = CreateUnderTest();

      // Act
      var actual = underTest.crewETCSpecified;

      // Assert
      Assert.Equal(true, actual);
   }

   [Fact]
   public void WorkTaskDto_SetValue_crewATC()
   {
      // Arrange
      var underTest = CreateUnderTest();

      // Act
      var actual = underTest.crewATC;

      // Assert
      Assert.Equal(new DateTime(2020, 1, 1, 1, 1, 7), actual);
   }

   [Fact]
   public void WorkTaskDto_SetValue_crewATCSpecified()
   {
      // Arrange
      var underTest = CreateUnderTest();

      // Act
      var actual = underTest.crewATCSpecified;

      // Assert
      Assert.Equal(true, actual);
   }

   [Fact]
   public void WorkTaskDto_SetValue_instruction()
   {
      // Arrange
      var underTest = CreateUnderTest();

      // Act
      var actual = underTest.instruction;

      // Assert
      Assert.Equal("text_8", actual);
   }

   [Fact]
   public void WorkTaskDto_SetValue_subject()
   {
      // Arrange
      var underTest = CreateUnderTest();

      // Act
      var actual = underTest.subject;

      // Assert
      Assert.Equal("text_9", actual);
   }

   [Fact]
   public void WorkTaskDto_SetValue_repairSequence()
   {
      // Arrange
      var underTest = CreateUnderTest();

      // Act
      var actual = underTest.repairSequence;

      // Assert
      Assert.Equal("text_10", actual);
   }

   [Fact]
   public void WorkTaskDto_SetValue_editable()
   {
      // Arrange
      var underTest = CreateUnderTest();

      // Act
      var actual = underTest.editable;

      // Assert
      Assert.Equal("text_11", actual);
   }

   [Fact]
   public void WorkTaskDto_SetValue_crewType()
   {
      // Arrange
      var underTest = CreateUnderTest();

      // Act
      var actual = underTest.crewType;

      // Assert
      Assert.Equal("text_12", actual);
   }

   [Fact]
   public void WorkTaskDto_SetValue_crewTypeSpecified()
   {
      // Arrange
      var underTest = CreateUnderTest();

      // Act
      var actual = underTest.crewTypeSpecified;

      // Assert
      Assert.Equal(true, actual);
   }

   [Fact]
   public void WorkTaskDto_SetValue_deviceType()
   {
      // Arrange
      var underTest = CreateUnderTest();

      // Act
      var actual = underTest.deviceType;

      // Assert
      Assert.Equal("text_13", actual);
   }

   [Fact]
   public void WorkTaskDto_SetValue_deviceTypeSpecified()
   {
      // Arrange
      var underTest = CreateUnderTest();

      // Act
      var actual = underTest.deviceTypeSpecified;

      // Assert
      Assert.Equal(true, actual);
   }

   [Fact]
   public void WorkTaskDto_SetValue_statusKind()
   {
      // Arrange
      var underTest = CreateUnderTest();

      // Act
      var actual = underTest.statusKind;

      // Assert
      Assert.Equal("text_14", actual);
   }

   [Fact]
   public void WorkTaskDto_SetValue_sequenceNumber()
   {
      // Arrange
      var underTest = CreateUnderTest();

      // Act
      var actual = underTest.sequenceNumber;

      // Assert
      Assert.Equal("text_15", actual);
   }

   [Fact]
   public void WorkTaskDto_SetValue_taskKind()
   {
      // Arrange
      var underTest = CreateUnderTest();

      // Act
      var actual = underTest.taskKind;

      // Assert
      Assert.Equal("text_16", actual);
   }

   [Fact]
   public void WorkTaskDto_SetValue_TaskIFSID()
   {
      // Arrange
      var underTest = CreateUnderTest();

      // Act
      var actual = underTest.TaskIFSID;

      // Assert
      Assert.Equal("text_17", actual);
   }

   [Fact]
   public void WorkTaskDto_SetValue_IFSStatus()
   {
      // Arrange
      var underTest = CreateUnderTest();

      // Act
      var actual = underTest.IFSStatus;

      // Assert
      Assert.Equal("text_18", actual);
   }

   private static WorkTaskDto CreateUnderTest()
   {
      return new WorkTaskDto()
      {
         mRID = "text_1",
         lastModifiedDateTime = new DateTime(2020, 1, 1, 1, 1, 2),
         lastModifiedDateTimeSpecified = true,
         creationDateTime = new DateTime(2020, 1, 1, 1, 1, 3),
         creationDateTimeSpecified = true,
         crewETA = new DateTime(2020, 1, 1, 1, 1, 4),
         crewETASpecified = true,
         crewATA = new DateTime(2020, 1, 1, 1, 1, 5),
         crewATASpecified = true,
         crewETC = new DateTime(2020, 1, 1, 1, 1, 6),
         crewETCSpecified = true,
         crewATC = new DateTime(2020, 1, 1, 1, 1, 7),
         crewATCSpecified = true,
         instruction = "text_8",
         subject = "text_9",
         repairSequence = "text_10",
         editable = "text_11",
         crewType = "text_12",
         crewTypeSpecified = true,
         deviceType = "text_13",
         deviceTypeSpecified = true,
         statusKind = "text_14",
         sequenceNumber = "text_15",
         taskKind = "text_16",
         Crews = new List<CrewDto>() { A.Fake<CrewDto>() }.ToArray(),
         Names = new List<WorkTaskNamesDto>() { A.Fake<WorkTaskNamesDto>() }.ToArray(),
         TaskIFSID = "text_17",
         IFSStatus = "text_18",
         TimeSchedules = new List<WorkTimeScheduleDto>() { A.Fake<WorkTimeScheduleDto>() }.ToArray(),
         Assets = new List<AssetDto>() { A.Fake<AssetDto>() }.ToArray(),
      };
   }

}
