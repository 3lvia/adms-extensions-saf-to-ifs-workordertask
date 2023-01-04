using System.Threading.Tasks;


namespace ServicesIfs
{
    public interface IAccessTokenService
    {
        Task<string> GetAccessToken();
    }

}


