using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesIfs
{
    public interface IIfsWorkOrder
    {
        string Publish(string request, bool bTask);

    }
}
