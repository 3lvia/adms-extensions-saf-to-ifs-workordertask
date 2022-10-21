using Azure;
using Model;
using Newtonsoft.Json;
using ServicesIfs;

using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ServicesIfs
{
    public class IfsCloudService : IIfsCloudService
    {
        private readonly IAccessTokenService _accessTokenService;


        public IfsCloudService(IAccessTokenService accessTokenService)
        {
            _accessTokenService = accessTokenService;
        }

        public string CreateWorkOrder(string request)
        {
            string webAddress = @"https://ifs-cloud-integration.dev-elvia.io/passthrough/forward/v1/CEntrWorkOrderHandling.svc/EntRCreateWorkOrder";

            HttpResponseMessage httpResponse = CallIfsCloud(request, webAddress);

            if (httpResponse.StatusCode == HttpStatusCode.OK)
            {
                string result = httpResponse.Content.ReadAsStringAsync().Result;

                var ser = JsonConvert.DeserializeObject<ResultValues>(result);

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



        public string CreateWorkOrderTask(string request)
        {
            string webAddress = @"https://ifs-cloud-integration.dev-elvia.io/passthrough/forward/v1/CEntrWorkOrderHandling.svc/EntRCreateWorkOrderTask";


            HttpResponseMessage httpResponse = CallIfsCloud(request, webAddress);

            if (httpResponse.StatusCode == HttpStatusCode.OK)
            {
                string result = httpResponse.Content.ReadAsStringAsync().Result;

                var ser = JsonConvert.DeserializeObject<ResultValuesTask>(result);

                var resultNumber = Regex.Match(ser.Value, @"\d+").Value;

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

    

        private HttpResponseMessage CallIfsCloud(string request, string webAddress)
        {
            var accessToken = _accessTokenService.GetAccessToken().Result;

            var _httpClient = new HttpClient() { BaseAddress = new Uri(webAddress) };

            _httpClient.DefaultRequestHeaders.TryAddWithoutValidation("Authorization", "Bearer " + accessToken);

            var httpBody = new StringContent(request, Encoding.UTF8, "application/json");

            var httpResponse = _httpClient.PostAsync(_httpClient.BaseAddress, httpBody).Result;
            return httpResponse;
        }
    }

}








//public string Publish(string request, bool bTask)
//{
//    //var _httpClient = new HttpClient() { BaseAddress = new Uri(@"ht tps://ifs-cloud-integration.dev-elvia.io/passthrough/forward/v1/CEntrWorkOrderHandling.svc/EntRCreateWorkOrder") };

//    string webAddress = @"https://ifs-cloud-integration.dev-elvia.io/passthrough/forward/v1/CEntrWorkOrderHandling.svc/EntRCreateWorkOrder";

//    if (bTask) webAddress += "Task";

//    HttpResponseMessage httpResponse = CallIfsCloud(request, webAddress);

//    if (httpResponse.StatusCode == HttpStatusCode.OK)
//    {

//        if (!bTask)
//        {
//            string result = httpResponse.Content.ReadAsStringAsync().Result;

//            var ser = JsonConvert.DeserializeObject<ResultValues>(result);

//            var result2 = Regex.Match(ser.Result, @"\d+").Value;

//            int debug = 12;

//            return result2;


//        }
//        else
//        {
//            string result = httpResponse.Content.ReadAsStringAsync().Result;

//            var ser = JsonConvert.DeserializeObject<ResultValuesTask>(result);

//            var result2 = Regex.Match(ser.Value, @"\d+").Value;

//            int debug = 12;

//            return result2;

//        }




//    }
//    else
//    {
//        //var errorMessage = httpResponse.Content.ReadAsStringAsync();
//        //var txt = @"Something went wrong when calling Convey. \r\n" + httpResponse.StatusCode + httpResponse.ReasonPhrase + errorMessage.Result;

//        //throw new Exception(txt);

//        throw new Exception($"Something went wrong when calling Convey.\r\n {httpResponse.StatusCode}:\r\n {httpResponse.ReasonPhrase}:\r\n {httpResponse.Content.ReadAsStringAsync().Result} \r\n\r\n");


//    }



//    return "ERROR"; // Task.CompletedTask;
//}




