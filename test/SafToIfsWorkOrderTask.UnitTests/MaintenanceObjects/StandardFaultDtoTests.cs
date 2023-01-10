using FakeItEasy;
using MaintenanceOrdersInBoundDomain;

namespace SafToSesam.UnitTests.MaintenanceObjects;

public class MaintenanceOrdersDtoStandardFaultDtoTests
{

   private static StandardFaultDto CreateUnderTest()
   {
      return new StandardFaultDto()
      {
         EventLog = A.Dummy<EventLog1Dto>(),
      };
   }

}
