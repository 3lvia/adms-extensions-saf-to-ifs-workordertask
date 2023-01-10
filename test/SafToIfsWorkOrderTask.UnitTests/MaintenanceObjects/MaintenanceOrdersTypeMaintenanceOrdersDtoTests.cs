using FakeItEasy;
using MaintenanceOrdersInBoundDomain;

namespace SafToSesam.UnitTests.MaintenanceObjects;

public class MaintenanceOrdersDtoMaintenanceOrdersTypeMaintenanceOrdersDtoTests
{

   private static MaintenanceOrdersTypeMaintenanceOrdersDto CreateUnderTest()
   {
      return new MaintenanceOrdersTypeMaintenanceOrdersDto()
      {
         Organisation = new List<OrganisationDto>() { A.Fake<OrganisationDto>() }.ToArray(),
         Work = new List<WorkDto>() { A.Fake<WorkDto>() }.ToArray(),
      };
   }

}
