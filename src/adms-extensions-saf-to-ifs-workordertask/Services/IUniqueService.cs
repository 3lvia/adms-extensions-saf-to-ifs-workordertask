using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ServicesUniqueId
{
    public interface IUniqueIdService
    {
        Task<Guid> GetUniqueId(string Name);

        Task<Guid> GetUniqueId2Async(string Name);
        Task<string> GetName(Guid UniqueId);
    }
}
