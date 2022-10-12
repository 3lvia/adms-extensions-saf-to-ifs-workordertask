using Elvia.Configuration.HashiVault;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;



namespace ServicesIfs
{


    public class AccessTokenService : IAccessTokenService
    {
        private readonly IClientCredentialsConfiguration _config;
        private readonly IMemoryCache _memoryCache;

        private const string AccessTokenMemoryCacheKey = "AccessTokenMemoryCacheKey";

        public AccessTokenService(IClientCredentialsConfiguration config, IMemoryCache memoryCache)
        {
            _config = config;
            _memoryCache = memoryCache;
        }

        //public AccessTokenService(IClientCredentialsConfiguration config)
        //{
        //    _config = config;
        //    //_memoryCache = memoryCache;
        //}


        //public async Task<string> GetAccessToken()
        //{
        //    //if (_memoryCache.TryGetValue(AccessTokenMemoryCacheKey, out string cachedAccessToken))
        //    //{
        //    //    return cachedAccessToken;
        //    //}

        //    HttpClient client = new HttpClient();

        //    HttpRequestMessage requestMessage = new HttpRequestMessage(HttpMethod.Post, _config.TokenEndpoint);


        //    SetHeaders(requestMessage.Headers);

        //    requestMessage.Content = new StringContent("grant_type=client_credentials&client_id=" + _config.ClientId + "&client_secret=" + _config.ClientSecret + "", Encoding.UTF8, "application/x-www-form-urlencoded");

        //    var svar = "";

        //    await client.SendAsync(requestMessage)
        //    .ContinueWith(async responseTask =>
        //    {
        //        Console.WriteLine("Response: {0}", responseTask.Result);
        //        var Content = await responseTask.Result.Content.ReadAsStringAsync();
        //        svar = Content;
        //        int debug = 1;
        //    });
        //    JObject jObject = JObject.Parse(svar);

        //    string token = jObject["access_token"].Value<string>();

        //    double expires = jObject["expires_in"].Value<double>();

        //    //var cacheEntryOptions = new MemoryCacheEntryOptions().SetAbsoluteExpiration(TimeSpan.FromSeconds(expires));
        //    //_memoryCache.Set(AccessTokenMemoryCacheKey, token, cacheEntryOptions);

        //    //System.Diagnostics.Debug.WriteLine("Token       " + token.Substring(0, 20) + "\r\n");

        //    return token;

        //}

        public async Task<string> GetAccessToken()
        {
            if (_memoryCache.TryGetValue(AccessTokenMemoryCacheKey, out string cachedAccessToken))
            {
                return cachedAccessToken;
            }

            HttpClient client = new HttpClient();

            HttpRequestMessage requestMessage = new HttpRequestMessage(HttpMethod.Post, _config.TokenEndpoint);


            SetHeaders(requestMessage.Headers);

            requestMessage.Content = new StringContent("grant_type=client_credentials&client_id=" + _config.ClientId + "&client_secret=" + _config.ClientSecret + "", Encoding.UTF8, "application/x-www-form-urlencoded");

            var svar = "";

            await client.SendAsync(requestMessage)
           .ContinueWith(async responseTask =>
           {
               Console.WriteLine("Response: {0}", responseTask.Result);
               var Content = await responseTask.Result.Content.ReadAsStringAsync();
               svar = Content;
               int debug = 1;
           });
            JObject jObject = JObject.Parse(svar);

            string token = jObject["access_token"].Value<string>();

            double expires = jObject["expires_in"].Value<double>();

            var cacheEntryOptions = new MemoryCacheEntryOptions().SetAbsoluteExpiration(TimeSpan.FromSeconds(expires));
            _memoryCache.Set(AccessTokenMemoryCacheKey, token, cacheEntryOptions);

            System.Diagnostics.Debug.WriteLine("Token       " + token.Substring(0, 20) + "\r\n");

            return token;


        }



        private static void SetHeaders(HttpRequestHeaders headers)
        {
            headers.Clear();

            headers.Accept.ParseAdd("*/*");
            headers.AcceptEncoding.ParseAdd("gzip,deflate");
            //headers.AcceptLanguage.ParseAdd("en-GB,en-us;q=0.8,en;q=0.6");
            //headers.UserAgent.ParseAdd(GetUserAgent);
            headers.Connection.TryParseAdd("keep-alive");

            //headers.Host = new Uri(LoginUrl).Host;
            //headers.Add("X-Requested-With", "XMLHttpRequest");         
        }



    }
}
