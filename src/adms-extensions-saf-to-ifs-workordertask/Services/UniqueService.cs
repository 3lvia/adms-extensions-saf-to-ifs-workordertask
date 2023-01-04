using Elvia.Configuration;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using ServicesIfs;
using System;
using System.Net;
using System.Net.Http;
using System.Text.Encodings.Web;
using System.Threading.Tasks;


namespace ServicesUniqueId
{
    public class UniqueIdService : IUniqueIdService
    {
        private HttpClient _httpClient { get; }
        public IAccessTokenService _accessTokenService { get; }
        private string _uniqueIdURL = "";
        //private string nameType = "3d99f02b-fef4-4669-b3f4-81a4ce7d0572";
        private string nameType = "d0d63167-a7ec-4904-ab3f-1d8224bcc8d0";


        public UniqueIdService(HttpClient httpClient, IAccessTokenService accessTokenService, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _accessTokenService = accessTokenService;
            _uniqueIdURL = configuration.EnsureHasValue("UniqueId:Endpoint");
        }


        public async Task<Guid> GetUniqueId(string Name)
        {
            string webRequest = _uniqueIdURL + "IdentifiedObject?name=" + UrlEncoder.Default.Encode(Name) + "&nameType=" + nameType + "&pageNumber=1&pageSize=300";

            var accessToken = await _accessTokenService.GetAccessToken();

            SetHeaders(accessToken, _httpClient);

    
            HttpResponseMessage httpResponse = await _httpClient.GetAsync(webRequest);

            if (httpResponse.StatusCode == HttpStatusCode.OK)
            {
                string result = await httpResponse.Content.ReadAsStringAsync();

                var uniqueIdResult = JsonConvert.DeserializeObject<Model.UniqueIdResult>(result);

                if (uniqueIdResult.totalRecords == 0)
                {
                    throw new Exception("### ERROR GetUniqueId name not found");
                }
                else if (uniqueIdResult.totalRecords > 1)
                {
                    throw new Exception("### ERROR GetUniqueId name not unique");
                }

                return uniqueIdResult.data[0].mrid;
            }
            else
            {
                throw new Exception("### ERROR GetUniqueId " + httpResponse.StatusCode.ToString());
            }

        }

        public async Task<string> GetName(Guid UniqueId)
        {
            var accessToken = await _accessTokenService.GetAccessToken();

            string webRequest = _uniqueIdURL + "IdentifiedObject/" + UniqueId.ToString();

            SetHeaders(accessToken, _httpClient);

            var httpResponse = await _httpClient.GetAsync(webRequest);

            if (httpResponse.StatusCode == HttpStatusCode.OK)
            {
                string result = await httpResponse.Content.ReadAsStringAsync();

                var uniqueNameResult = JsonConvert.DeserializeObject<Model.UniqueNameResult>(result);

                if (uniqueNameResult.names.Length != 1)
                {
                    throw new Exception("### ERROR GetUniqueId name not unique");
                }
                return uniqueNameResult.names[0].name;
            }
            else
            {
                throw new Exception("### ERROR GetNameByUniqueId " + httpResponse.StatusCode.ToString());
            }
        }

        private static void SetHeaders(string accessToken, HttpClient _httpClient)
        {
            _httpClient.DefaultRequestHeaders.Clear();
            _httpClient.DefaultRequestHeaders.TryAddWithoutValidation("Authorization", "Bearer " + accessToken);
            _httpClient.DefaultRequestHeaders.TryAddWithoutValidation("api-version", "1.0");
            _httpClient.DefaultRequestHeaders.TryAddWithoutValidation("accept", "text/plain");
        }
    }
}
