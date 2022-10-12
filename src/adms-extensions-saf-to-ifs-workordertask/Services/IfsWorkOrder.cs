using Azure;
using Newtonsoft.Json;
using ServicesIfs;

using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ServicesIfs
{
    public class IfsWorkOrder : IIfsWorkOrder
    {
        private readonly IAccessTokenService _accessTokenService;


        public IfsWorkOrder(IAccessTokenService accessTokenService)
        {
            _accessTokenService = accessTokenService;
        }


        public string Publish(string request, bool bTask)
        {
            //var _httpClient = new HttpClient() { BaseAddress = new Uri(@"ht tps://ifs-cloud-integration.dev-elvia.io/passthrough/forward/v1/CEntrWorkOrderHandling.svc/EntRCreateWorkOrder") };

            string webAddress = @"https://ifs-cloud-integration.dev-elvia.io/passthrough/forward/v1/CEntrWorkOrderHandling.svc/EntRCreateWorkOrder";

            if (bTask) webAddress += "Task";


            var accessToken = _accessTokenService.GetAccessToken().Result;

            var _httpClient = new HttpClient() { BaseAddress = new Uri(webAddress) };

            _httpClient.DefaultRequestHeaders.TryAddWithoutValidation("Authorization", "Bearer " + accessToken);

             
            //var jsonBody = JsonConvert.SerializeObject(job);

            var httpBody = new StringContent(request, Encoding.UTF8, "application/json");

            var httpResponse = _httpClient.PostAsync(_httpClient.BaseAddress, httpBody).Result;

            

            
            if (httpResponse.StatusCode == HttpStatusCode.OK)
            {

                if (!bTask)
                {
                    string result = httpResponse.Content.ReadAsStringAsync().Result;

                    var ser = JsonConvert.DeserializeObject<ResultValues>(result);

                    var result2 = Regex.Match(ser.Result, @"\d+").Value;

                    int debug = 12;

                    return result2;


                }
                else
                {
                    string result = httpResponse.Content.ReadAsStringAsync().Result;

                    var ser = JsonConvert.DeserializeObject<ResultValuesTask>(result);

                    var result2 = Regex.Match(ser.Value, @"\d+").Value;

                    int debug = 12;

                    return result2;

                }

              

 
            }
            else
            {
                //var errorMessage = httpResponse.Content.ReadAsStringAsync();
                //var txt = @"Something went wrong when calling Convey. \r\n" + httpResponse.StatusCode + httpResponse.ReasonPhrase + errorMessage.Result;

                //throw new Exception(txt);

                throw new Exception($"Something went wrong when calling Convey.\r\n {httpResponse.StatusCode}:\r\n {httpResponse.ReasonPhrase}:\r\n {httpResponse.Content.ReadAsStringAsync().Result} \r\n\r\n");


            }



            return "ERROR"; // Task.CompletedTask;
        }
    }


    public class ResultValues
    {
        //public string @odata.context { get; set; }

        public string ReturnValue { get; set; }

        public string Status { get; set; }

        public string Result { get; set; }


    }

    public class ResultValuesTask
    {
        //public string @odata.context { get; set; }

        public string Value { get; set; }

        //public string Status { get; set; }

        //public string Result { get; set; }


    }
}


