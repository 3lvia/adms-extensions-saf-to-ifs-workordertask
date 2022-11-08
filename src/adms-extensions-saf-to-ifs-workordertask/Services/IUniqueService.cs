using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ServicesUniqueId
{
    public interface IUniqueIdService
    {
        string CreateUniqueId(Guid id, string Name, string Description);

        string GetObjectByUniqueId(string request);

    }
}
