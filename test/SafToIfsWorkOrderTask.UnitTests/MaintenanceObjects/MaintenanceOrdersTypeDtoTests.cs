using FakeItEasy;
using MaintenanceOrdersInBoundDomain;
namespace SafToSesam.UnitTests.MaintenanceObjects;

public class MaintenanceOrdersDtoMaintenanceOrdersTypeDtoTests
{

   private static MaintenanceOrdersTypeDto CreateUnderTest()
   {
      return new MaintenanceOrdersTypeDto()
      {
         MaintenanceOrders = A.Dummy<MaintenanceOrdersTypeMaintenanceOrdersDto>(),
      };
   }

}
