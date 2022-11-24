using Azure.Core;
using Confluent.Kafka;
using Elvia.Configuration;
using k8s.Util.Common;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
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
            _httpClient.BaseAddress = new Uri(_uniqueIdURL);
        }


        public async Task<Guid> GetUniqueId2Async(string Name)
        {
         
            HttpRequestMessage requestMessage = new HttpRequestMessage(HttpMethod.Get, _uniqueIdURL);

            //_httpClient.DefaultRequestHeaders.TryAddWithoutValidation("Authorization", "Bearer " + accessToken);
            //_httpClient.DefaultRequestHeaders.TryAddWithoutValidation("api-version", "1.0");
            //_httpClient.DefaultRequestHeaders.TryAddWithoutValidation("accept", "text/plain");
            var accessToken = _accessTokenService.GetAccessToken().Result;

           // SetHeaders(accessToken, _httpClient);


           // requestMessage.Content = new StringContent("IdentifiedObject?name=" + UrlEncoder.Default.Encode(Name) + "&nameType=" + nameType + "&pageNumber=1&pageSize=300");
    
           // var svar = "";
           // await _httpClient.GetAsync(requestMessage)
           //.ContinueWith(async responseTask =>
           //{
           //    Console.WriteLine("Response: {0}", responseTask.Result);
           //    var Content = await responseTask.Result.Content.ReadAsStringAsync();
           //    svar = Content;
           //    int debug = 1;
           //});
         
         
            //Temp
            //Console.WriteLine("AccessToken fetched: " + token.Substring(0, 4));

            return Guid.NewGuid();

        }




        public async Task<Guid> GetUniqueId(string Name)
        {
            var accessToken = _accessTokenService.GetAccessToken().Result;

            string webAddress = "IdentifiedObject?name=" + UrlEncoder.Default.Encode(Name) + "&nameType=" + nameType + "&pageNumber=1&pageSize=300";


            //HttpRequestMessage requestMessage = new HttpRequestMessage(HttpMethod.Get, webAddress);

            SetHeaders(accessToken, _httpClient);

            var httpResponse = await _httpClient.GetAsync(webAddress);

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


        public async Task<string> GetName(Guid UniqueId)
        {
            var accessToken = _accessTokenService.GetAccessToken().Result;

            string webAddress = "IdentifiedObject/" + UniqueId.ToString();

            SetHeaders(accessToken, _httpClient);

            var httpResponse = await _httpClient.GetAsync(webAddress);

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
