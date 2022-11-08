using Azure.Core;
using k8s.Util.Common;
using Newtonsoft.Json;
using ServicesIfs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;


namespace ServicesUniqueId
{
    public class UniqueIdService : IUniqueIdService
    {   
        public IAccessTokenService _accessTokenService { get; }
      
        public UniqueIdService(IAccessTokenService accessTokenService)
        {
            _accessTokenService = accessTokenService;
        }



        public string CreateUniqueId(Guid id, string Name, string Description)
        {
            //string webAddress = @"h ttps://uniqueid-api.dev-elvia.io/ObjectType";

            string webAddress = @"https://uniqueid-api.elvia.io/IdentifiedObject/26adce8e-2933-4728-83c5-a609ed964faf";

            var obj = new Model.UniqueId
            {
                mrid = id.ToString(),
                name = Name,
                description = Description
            };


            var request = JsonConvert.SerializeObject(obj, Newtonsoft.Json.Formatting.Indented);

              
            HttpResponseMessage httpResponse = CallUniqueIdAtlas(request, webAddress);


            string result12 = httpResponse.Content.ReadAsStringAsync().Result;

            if (httpResponse.StatusCode == HttpStatusCode.OK)
            {

                string result = httpResponse.Content.ReadAsStringAsync().Result;

                string cc = "";

            }

            return "";
        }


        public string GetObjectByUniqueId(string request)
        {
            throw new NotImplementedException();
        }


        private HttpResponseMessage CallUniqueIdAtlas(string request, string webAddress)
        {
            var accessToken = _accessTokenService.GetAccessToken().Result;

            var _httpClient = new HttpClient() { BaseAddress = new Uri(webAddress)  };


            webAddress = @"https://uniqueid-api.dev-elvia.io/IdentifiedObject/b2c83910-4e49-4d98-b253-bfc943c9773c";

            HttpRequestMessage requestMessage = new HttpRequestMessage(HttpMethod.Get, webAddress);


            //SetHeaders(requestMessage.Headers);

 
           _httpClient.DefaultRequestHeaders.TryAddWithoutValidation("Authorization", "Bearer " + accessToken);
           _httpClient.DefaultRequestHeaders.TryAddWithoutValidation("api-version", "1.0");
            _httpClient.DefaultRequestHeaders.TryAddWithoutValidation("accept", "text/plain");

            //var httpBody = new StringContent(request, Encoding.UTF8, "application/json");

            //var httpBody = new StringContent("", Encoding.UTF8, "application/json");

            //var httpResponse = _httpClient.GetAsync(_httpClient.BaseAddress, httpBody).Result;

            var httpResponse = _httpClient.GetAsync(_httpClient.BaseAddress).Result;

            return httpResponse;
        }


        private static void SetHeaders(HttpRequestHeaders headers)
        {
            headers.Clear();

            headers.Accept.ParseAdd("*/*");
            headers.AcceptEncoding.ParseAdd("gzip,deflate");
            //headers.AcceptLanguage.ParseAdd("en-GB,en-us;q=0.8,en;q=0.6");
            //headers.UserAgent.ParseAdd(GetUserAgent);
    
           
            headers.Add("api-version","1.0");
            headers.Connection.TryParseAdd("keep-alive");
            //headers.Host = new Uri(LoginUrl).Host;
            //headers.Add("X-Requested-With", "XMLHttpRequest");
            //api-version: 1.0
        }


    }
}
