using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace adms_extensions_saf_to_ifs_workordertask.PerformMessages
{
    
    public interface IPerformMessageMaintenanceOrder
    {

        (string, string) Invoke(string xmlMessage);


    }
}
