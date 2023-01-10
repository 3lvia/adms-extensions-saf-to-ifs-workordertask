using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesIfs
{
    public interface IClientCredentialsConfiguration
    {
        string ClientId();
        string ClientSecret();
        string TokenEndpoint();
    }
}

