using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ServicesIfs
{
    public interface IIfsCloudService
    {
        Task<string> CreateWorkOrder(string request);

        Task<string> CreateWorkOrderTask(string request);

    }
}
