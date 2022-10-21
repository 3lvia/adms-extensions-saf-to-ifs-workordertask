using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ServicesIfs
{
    public interface IIfsCloudService
    {
        string CreateWorkOrder(string request);

        string CreateWorkOrderTask(string request);

    }
}
