using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ServicesUniqueId
{
    public interface IUniqueIdService
    {
        Guid GetUniqueId(string Name);
        string GetName(Guid UniqueId);
    }
}
