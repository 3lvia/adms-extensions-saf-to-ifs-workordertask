using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesIfs
{
    public interface IClientCredentialsConfiguration
    {
        string ClientId { get; init; }
        string ClientSecret { get; init; }
        string TokenEndpoint { get; init; }
    }
}

