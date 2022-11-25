using Elvia.Configuration;
using Microsoft.Extensions.Configuration;
using Model;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ServicesIfs
{
    public class IfsCloudService : IIfsCloudService
    {
        private readonly HttpClient _httpClient;
        private readonly IAccessTokenService _accessTokenService;
        private readonly IConfiguration _configuration;

        public IfsCloudService(HttpClient httpClient, IAccessTokenService accessTokenService, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _accessTokenService = accessTokenService;
            _configuration = configuration;
        }

        public async Task<string> CreateWorkOrder(string request)
        {
            Uri ifsUri = new Uri(_configuration.EnsureHasValue("URI:IfsCloudWorkOrder"));

            HttpResponseMessage httpResponse = await CallIfsCloud(request, ifsUri);

            if (httpResponse.StatusCode == HttpStatusCode.OK)
            {
                string result = await httpResponse.Content.ReadAsStringAsync();

                var ser = JsonConvert.DeserializeObject<ResultValuesIfs>(result);

                var resultNumber = Regex.Match(ser.Result, @"\d+").Value;

                if (resultNumber.Length == 0)
                {
                    throw new Exception($"Something went wrong when calling IFS-Cloud WorkOrder - for CreateWorkOrderTask.\r\n {httpResponse.StatusCode}:\r\n {httpResponse.ReasonPhrase}:\r\n {httpResponse.Content.ReadAsStringAsync().Result} \r\n\r\n");
                }
                return resultNumber;
            }
            else
            {
                throw new Exception($"Something went wrong when calling IFS-Cloud WorkOrder - for CreateWorkOrder.\r\n {httpResponse.StatusCode}:\r\n {httpResponse.ReasonPhrase}:\r\n {httpResponse.Content.ReadAsStringAsync().Result} \r\n\r\n");
            }
        }



        public async Task<string> CreateWorkOrderTask(string request)
        {
            Uri ifsURI = new Uri(_configuration.EnsureHasValue("URI:IfsCloudWorkOrderTask"));

            HttpResponseMessage httpResponse = await CallIfsCloud(request, ifsURI);

            if (httpResponse.StatusCode == HttpStatusCode.OK)
            {
                string result = await httpResponse.Content.ReadAsStringAsync();

                var ser = JsonConvert.DeserializeObject<ResultValuesIfs>(result);

                var resultNumber = Regex.Match(ser.Result, @"\d+").Value;

                if (resultNumber.Length == 0)
                {
                    throw new Exception($"Something went wrong when calling IFS-Cloud WorkOrder - for CreateWorkOrderTask.\r\n {httpResponse.StatusCode}:\r\n {httpResponse.ReasonPhrase}:\r\n {httpResponse.Content.ReadAsStringAsync().Result} \r\n\r\n");
                }

                return resultNumber;
            }
            else
            {
                throw new Exception($"Something went wrong when calling IFS-Cloud WorkOrder - for CreateWorkOrderTask.\r\n {httpResponse.StatusCode}:\r\n {httpResponse.ReasonPhrase}:\r\n {httpResponse.Content.ReadAsStringAsync().Result} \r\n\r\n");
            }
        }



        private async Task<HttpResponseMessage> CallIfsCloud(string request, Uri ifsUri)
        {
            var accessToken = await _accessTokenService.GetAccessToken();

            _httpClient.DefaultRequestHeaders.Clear();
            _httpClient.DefaultRequestHeaders.TryAddWithoutValidation("Authorization", "Bearer " + accessToken);

            var httpBody = new StringContent(request, Encoding.UTF8, "application/json");

            var httpResponse = await _httpClient.PostAsync(ifsUri, httpBody);
            return httpResponse;
        }
    }

}



