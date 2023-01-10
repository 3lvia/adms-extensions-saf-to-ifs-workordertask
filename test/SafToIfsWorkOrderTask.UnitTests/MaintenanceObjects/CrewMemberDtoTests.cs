using FakeItEasy;
using MaintenanceOrdersInBoundDomain;

namespace SafToSesam.UnitTests.MaintenanceObjects;

public class MaintenanceOrdersDtoCrewMemberDtoTests
{

   private static CrewMemberDto CreateUnderTest()
   {
      return new CrewMemberDto()
      {
         Person = A.Dummy<CrewMemberPersonDto>(),
      };
   }

}
