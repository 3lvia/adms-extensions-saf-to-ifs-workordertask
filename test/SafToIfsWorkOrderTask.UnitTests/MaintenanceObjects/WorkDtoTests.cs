using FakeItEasy;
using MaintenanceOrdersInBoundDomain;
using Xunit;
namespace SafToSesam.UnitTests.MaintenanceObjects;

public class MaintenanceOrdersDtoWorkDtoTests
{

   [Fact]
   public void WorkDto_SetValue_mRID()
   {
      // Arrange
      var underTest = CreateUnderTest();

      // Act
      var actual = underTest.mRID;

      // Assert
      Assert.Equal("text_1", actual);
   }

   [Fact]
   public void WorkDto_SetValue_RECORD_OID()
   {
      // Arrange
      var underTest = CreateUnderTest();

      // Act
      var actual = underTest.RECORD_OID;

      // Assert
      Assert.Equal("text_2", actual);
   }

   [Fact]
   public void WorkDto_SetValue_Category()
   {
      // Arrange
      var underTest = CreateUnderTest();

      // Act
      var actual = underTest.Category;

      // Assert
      Assert.Equal("text_3", actual);
   }

   [Fact]
   public void WorkDto_SetValue_TYPE()
   {
      // Arrange
      var underTest = CreateUnderTest();

      // Act
      var actual = underTest.TYPE;

      // Assert
      Assert.Equal("text_4", actual);
   }

   [Fact]
   public void WorkDto_SetValue_WorkCategory()
   {
      // Arrange
      var underTest = CreateUnderTest();

      // Act
      var actual = underTest.WorkCategory;

      // Assert
      Assert.Equal("text_5", actual);
   }

   [Fact]
   public void WorkDto_SetValue_lastModifiedDateTime()
   {
      // Arrange
      var underTest = CreateUnderTest();

      // Act
      var actual = underTest.lastModifiedDateTime;

      // Assert
      Assert.Equal(new DateTime(2020, 1, 1, 1, 1, 6), actual);
   }

   [Fact]
   public void WorkDto_SetValue_lastModifiedDateTimeSpecified()
   {
      // Arrange
      var underTest = CreateUnderTest();

      // Act
      var actual = underTest.lastModifiedDateTimeSpecified;

      // Assert
      Assert.Equal(true, actual);
   }

   [Fact]
   public void WorkDto_SetValue_statusKind()
   {
      // Arrange
      var underTest = CreateUnderTest();

      // Act
      var actual = underTest.statusKind;

      // Assert
      Assert.Equal("text_7", actual);
   }

   [Fact]
   public void WorkDto_SetValue_WorkStatusNum()
   {
      // Arrange
      var underTest = CreateUnderTest();

      // Act
      var actual = underTest.WorkStatusNum;

      // Assert
      Assert.Equal("text_8", actual);
   }

   [Fact]
   public void WorkDto_SetValue_WorkOrderNo()
   {
      // Arrange
      var underTest = CreateUnderTest();

      // Act
      var actual = underTest.WorkOrderNo;

      // Assert
      Assert.Equal("text_9", actual);
   }

   [Fact]
   public void WorkDto_SetValue_IFS_RECORD_NUM()
   {
      // Arrange
      var underTest = CreateUnderTest();

      // Act
      var actual = underTest.IFS_RECORD_NUM;

      // Assert
      Assert.Equal("text_10", actual);
   }

   [Fact]
   public void WorkDto_SetValue_IFSStatus()
   {
      // Arrange
      var underTest = CreateUnderTest();

      // Act
      var actual = underTest.IFSStatus;

      // Assert
      Assert.Equal("text_11", actual);
   }

   [Fact]
   public void WorkDto_SetValue_subject()
   {
      // Arrange
      var underTest = CreateUnderTest();

      // Act
      var actual = underTest.subject;

      // Assert
      Assert.Equal("text_12", actual);
   }

   [Fact]
   public void WorkDto_SetValue_EST_TS()
   {
      // Arrange
      var underTest = CreateUnderTest();

      // Act
      var actual = underTest.EST_TS;

      // Assert
      Assert.Equal(new DateTime(2020, 1, 1, 1, 1, 13), actual);
   }

   [Fact]
   public void WorkDto_SetValue_EST_TSSpecified()
   {
      // Arrange
      var underTest = CreateUnderTest();

      // Act
      var actual = underTest.EST_TSSpecified;

      // Assert
      Assert.Equal(true, actual);
   }

   [Fact]
   public void WorkDto_SetValue_ACT_TS()
   {
      // Arrange
      var underTest = CreateUnderTest();

      // Act
      var actual = underTest.ACT_TS;

      // Assert
      Assert.Equal(new DateTime(2020, 1, 1, 1, 1, 14), actual);
   }

   [Fact]
   public void WorkDto_SetValue_ACT_TSSpecified()
   {
      // Arrange
      var underTest = CreateUnderTest();

      // Act
      var actual = underTest.ACT_TSSpecified;

      // Assert
      Assert.Equal(true, actual);
   }

   [Fact]
   public void WorkDto_SetValue_EST_TC()
   {
      // Arrange
      var underTest = CreateUnderTest();

      // Act
      var actual = underTest.EST_TC;

      // Assert
      Assert.Equal(new DateTime(2020, 1, 1, 1, 1, 15), actual);
   }

   [Fact]
   public void WorkDto_SetValue_EST_TCSpecified()
   {
      // Arrange
      var underTest = CreateUnderTest();

      // Act
      var actual = underTest.EST_TCSpecified;

      // Assert
      Assert.Equal(true, actual);
   }

   [Fact]
   public void WorkDto_SetValue_ACT_TC()
   {
      // Arrange
      var underTest = CreateUnderTest();

      // Act
      var actual = underTest.ACT_TC;

      // Assert
      Assert.Equal(new DateTime(2020, 1, 1, 1, 1, 16), actual);
   }

   [Fact]
   public void WorkDto_SetValue_ACT_TCSpecified()
   {
      // Arrange
      var underTest = CreateUnderTest();

      // Act
      var actual = underTest.ACT_TCSpecified;

      // Assert
      Assert.Equal(true, actual);
   }

   [Fact]
   public void WorkDto_SetValue_OPERATOR_EST_TS()
   {
      // Arrange
      var underTest = CreateUnderTest();

      // Act
      var actual = underTest.OPERATOR_EST_TS;

      // Assert
      Assert.Equal(new DateTime(2020, 1, 1, 1, 1, 17), actual);
   }

   [Fact]
   public void WorkDto_SetValue_OPERATOR_EST_TSSpecified()
   {
      // Arrange
      var underTest = CreateUnderTest();

      // Act
      var actual = underTest.OPERATOR_EST_TSSpecified;

      // Assert
      Assert.Equal(true, actual);
   }

   [Fact]
   public void WorkDto_SetValue_OPERATOR_BEGIN_EST()
   {
      // Arrange
      var underTest = CreateUnderTest();

      // Act
      var actual = underTest.OPERATOR_BEGIN_EST;

      // Assert
      Assert.Equal(new DateTime(2020, 1, 1, 1, 1, 18), actual);
   }

   [Fact]
   public void WorkDto_SetValue_OPERATOR_BEGIN_ESTSpecified()
   {
      // Arrange
      var underTest = CreateUnderTest();

      // Act
      var actual = underTest.OPERATOR_BEGIN_ESTSpecified;

      // Assert
      Assert.Equal(true, actual);
   }

   [Fact]
   public void WorkDto_SetValue_OPERATOR_END_EST()
   {
      // Arrange
      var underTest = CreateUnderTest();

      // Act
      var actual = underTest.OPERATOR_END_EST;

      // Assert
      Assert.Equal(new DateTime(2020, 1, 1, 1, 1, 19), actual);
   }

   [Fact]
   public void WorkDto_SetValue_OPERATOR_END_ESTSpecified()
   {
      // Arrange
      var underTest = CreateUnderTest();

      // Act
      var actual = underTest.OPERATOR_END_ESTSpecified;

      // Assert
      Assert.Equal(true, actual);
   }

   [Fact]
   public void WorkDto_SetValue_OPERATOR_EST_TC()
   {
      // Arrange
      var underTest = CreateUnderTest();

      // Act
      var actual = underTest.OPERATOR_EST_TC;

      // Assert
      Assert.Equal(new DateTime(2020, 1, 1, 1, 1, 20), actual);
   }

   [Fact]
   public void WorkDto_SetValue_OPERATOR_EST_TCSpecified()
   {
      // Arrange
      var underTest = CreateUnderTest();

      // Act
      var actual = underTest.OPERATOR_EST_TCSpecified;

      // Assert
      Assert.Equal(true, actual);
   }

   [Fact]
   public void WorkDto_SetValue_END_ACT_DELAY_CAUSE()
   {
      // Arrange
      var underTest = CreateUnderTest();

      // Act
      var actual = underTest.END_ACT_DELAY_CAUSE;

      // Assert
      Assert.Equal("text_21", actual);
   }

   [Fact]
   public void WorkDto_SetValue_CAUSE_OR_REASON()
   {
      // Arrange
      var underTest = CreateUnderTest();

      // Act
      var actual = underTest.CAUSE_OR_REASON;

      // Assert
      Assert.Equal("text_22", actual);
   }

   [Fact]
   public void WorkDto_SetValue_FAULT_CATEGORY()
   {
      // Arrange
      var underTest = CreateUnderTest();

      // Act
      var actual = underTest.FAULT_CATEGORY;

      // Assert
      Assert.Equal("text_23", actual);
   }

   [Fact]
   public void WorkDto_SetValue_FAULT_EQUIPMENT()
   {
      // Arrange
      var underTest = CreateUnderTest();

      // Act
      var actual = underTest.FAULT_EQUIPMENT;

      // Assert
      Assert.Equal("text_24", actual);
   }

   [Fact]
   public void WorkDto_SetValue_DeviceLocation()
   {
      // Arrange
      var underTest = CreateUnderTest();

      // Act
      var actual = underTest.DeviceLocation;

      // Assert
      Assert.Equal("text_25", actual);
   }

   [Fact]
   public void WorkDto_SetValue_EMERGENCY_HAZARD_INDICATOR()
   {
      // Arrange
      var underTest = CreateUnderTest();

      // Act
      var actual = underTest.EMERGENCY_HAZARD_INDICATOR;

      // Assert
      Assert.Equal("text_26", actual);
   }

   [Fact]
   public void WorkDto_SetValue_POLE_NUMBER()
   {
      // Arrange
      var underTest = CreateUnderTest();

      // Act
      var actual = underTest.POLE_NUMBER;

      // Assert
      Assert.Equal("text_27", actual);
   }

   [Fact]
   public void WorkDto_SetValue_SUBSTATION()
   {
      // Arrange
      var underTest = CreateUnderTest();

      // Act
      var actual = underTest.SUBSTATION;

      // Assert
      Assert.Equal("text_28", actual);
   }

   [Fact]
   public void WorkDto_SetValue_STORM_OID()
   {
      // Arrange
      var underTest = CreateUnderTest();

      // Act
      var actual = underTest.STORM_OID;

      // Assert
      Assert.Equal("text_29", actual);
   }

   [Fact]
   public void WorkDto_SetValue_CREATION_USER_NAME()
   {
      // Arrange
      var underTest = CreateUnderTest();

      // Act
      var actual = underTest.CREATION_USER_NAME;

      // Assert
      Assert.Equal("text_30", actual);
   }

   [Fact]
   public void WorkDto_SetValue_CREATION_TIMESTAMP()
   {
      // Arrange
      var underTest = CreateUnderTest();

      // Act
      var actual = underTest.CREATION_TIMESTAMP;

      // Assert
      Assert.Equal(new DateTime(2020, 1, 1, 1, 1, 31), actual);
   }

   [Fact]
   public void WorkDto_SetValue_CREATION_TIMESTAMPSpecified()
   {
      // Arrange
      var underTest = CreateUnderTest();

      // Act
      var actual = underTest.CREATION_TIMESTAMPSpecified;

      // Assert
      Assert.Equal(true, actual);
   }

   [Fact]
   public void WorkDto_SetValue_POWER_IS_CUT()
   {
      // Arrange
      var underTest = CreateUnderTest();

      // Act
      var actual = underTest.POWER_IS_CUT;

      // Assert
      Assert.Equal("text_32", actual);
   }

   [Fact]
   public void WorkDto_SetValue_userName()
   {
      // Arrange
      var underTest = CreateUnderTest();

      // Act
      var actual = underTest.userName;

      // Assert
      Assert.Equal("text_33", actual);
   }

   private static WorkDto CreateUnderTest()
   {
      return new WorkDto()
      {
         mRID = "text_1",
         RECORD_OID = "text_2",
         Category = "text_3",
         TYPE = "text_4",
         WorkCategory = "text_5",
         lastModifiedDateTime = new DateTime(2020, 1, 1, 1, 1, 6),
         lastModifiedDateTimeSpecified = true,
         statusKind = "text_7",
         WorkStatusNum = "text_8",
         Names = new List<WorkNamesDto>() { A.Fake<WorkNamesDto>() }.ToArray(),
         WorkOrderNo = "text_9",
         IFS_RECORD_NUM = "text_10",
         IFSStatus = "text_11",
         priority = A.Dummy<WorkPriorityDto>(),
         subject = "text_12",
         TriggerEquipment = A.Dummy<EquipmentDto>(),
         TimeSchedules = new List<WorkTimeScheduleDto>() { A.Fake<WorkTimeScheduleDto>() }.ToArray(),
         EST_TS = new DateTime(2020, 1, 1, 1, 1, 13),
         EST_TSSpecified = true,
         ACT_TS = new DateTime(2020, 1, 1, 1, 1, 14),
         ACT_TSSpecified = true,
         EST_TC = new DateTime(2020, 1, 1, 1, 1, 15),
         EST_TCSpecified = true,
         ACT_TC = new DateTime(2020, 1, 1, 1, 1, 16),
         ACT_TCSpecified = true,
         OPERATOR_EST_TS = new DateTime(2020, 1, 1, 1, 1, 17),
         OPERATOR_EST_TSSpecified = true,
         OPERATOR_BEGIN_EST = new DateTime(2020, 1, 1, 1, 1, 18),
         OPERATOR_BEGIN_ESTSpecified = true,
         OPERATOR_END_EST = new DateTime(2020, 1, 1, 1, 1, 19),
         OPERATOR_END_ESTSpecified = true,
         OPERATOR_EST_TC = new DateTime(2020, 1, 1, 1, 1, 20),
         OPERATOR_EST_TCSpecified = true,
         END_ACT_DELAY_CAUSE = "text_21",
         CAUSE_OR_REASON = "text_22",
         FAULT_CATEGORY = "text_23",
         FAULT_EQUIPMENT = "text_24",
         DeviceLocation = "text_25",
         EMERGENCY_HAZARD_INDICATOR = "text_26",
         POLE_NUMBER = "text_27",
         SUBSTATION = "text_28",
         STORM_OID = "text_29",
         CREATION_USER_NAME = "text_30",
         CREATION_TIMESTAMP = new DateTime(2020, 1, 1, 1, 1, 31),
         CREATION_TIMESTAMPSpecified = true,
         POWER_IS_CUT = "text_32",
         WorkLocation = A.Dummy<WorkLocationDto>(),
         userName = "text_33",
         WorkTasks = new List<WorkTaskDto>() { A.Fake<WorkTaskDto>() }.ToArray(),
      };
   }

}
