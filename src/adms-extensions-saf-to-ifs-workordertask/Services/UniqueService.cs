using Azure.Core;
using Elvia.Configuration;
using k8s.Util.Common;
using Microsoft.Extensions.Configuration;
using Model;
using Newtonsoft.Json;
using ServicesIfs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;


namespace ServicesUniqueId
{
    public class UniqueIdService : IUniqueIdService
    {
        public IAccessTokenService _accessTokenService { get; }
        private string _uniqueIdURL = "";
        private string nameType = "3d99f02b-fef4-4669-b3f4-81a4ce7d0572";
            //"d0d63167-a7ec-4904-ab3f-1d8224bcc8d0";


        public UniqueIdService(IAccessTokenService accessTokenService, IConfiguration configuration)
        {
            _accessTokenService = accessTokenService;
            _uniqueIdURL = configuration.EnsureHasValue("UniqueId:Endpoint");
        }

        public Guid GetUniqueId(string Name)
        {
            var accessToken = _accessTokenService.GetAccessToken().Result;

            string webAddress = _uniqueIdURL + "IdentifiedObject?name=" + UrlEncoder.Default.Encode(Name) + "&nameType=" + nameType + "&pageNumber=1&pageSize=300";


            HttpRequestMessage requestMessage = new HttpRequestMessage(HttpMethod.Get, webAddress);

            var _httpClient = new HttpClient() { BaseAddress = new Uri(webAddress) };

            SetHeaders(accessToken, _httpClient);

            var httpResponse = _httpClient.GetAsync(_httpClient.BaseAddress).Result;

            if (httpResponse.StatusCode == HttpStatusCode.OK)
            {
                string result = httpResponse.Content.ReadAsStringAsync().Result;

                var ser = JsonConvert.DeserializeObject<Model.UniqueIdResult>(result);

                if (ser.totalRecords == 0)
                {
                    throw new Exception("### ERROR GetUniqueId name not found");
                }
                else if (ser.totalRecords > 1)
                {
                    throw new Exception("### ERROR GetUniqueId name not unique");
                }

                return ser.data[0].mrid;
            }
            else
            {
                throw new Exception("### ERROR GetUniqueId " + httpResponse.StatusCode.ToString());
            }
        }


        public string GetName(Guid UniqueId)
        {
            var accessToken = _accessTokenService.GetAccessToken().Result;

            string webAddress = _uniqueIdURL + "IdentifiedObject/" + UniqueId.ToString();


            HttpRequestMessage requestMessage = new HttpRequestMessage(HttpMethod.Get, webAddress);

            var _httpClient = new HttpClient() { BaseAddress = new Uri(webAddress) };

            SetHeaders(accessToken, _httpClient);

            var httpResponse = _httpClient.GetAsync(_httpClient.BaseAddress).Result;

            if (httpResponse.StatusCode == HttpStatusCode.OK)
            {
                string result = httpResponse.Content.ReadAsStringAsync().Result;

                var ser = JsonConvert.DeserializeObject<Model.UniqueNameResult>(result);

                if (ser.names.Length != 1)
                {
                    throw new Exception("### ERROR GetUniqueId name not unique");
                }

                return ser.names[0].name;
            }
            else
            {
                throw new Exception("### ERROR GetNameByUniqueId " + httpResponse.StatusCode.ToString());
            }
        }

        private static void SetHeaders(string accessToken, HttpClient _httpClient)
        {
            _httpClient.DefaultRequestHeaders.TryAddWithoutValidation("Authorization", "Bearer " + accessToken);
            _httpClient.DefaultRequestHeaders.TryAddWithoutValidation("api-version", "1.0");
            _httpClient.DefaultRequestHeaders.TryAddWithoutValidation("accept", "text/plain");
        }


    }
}
