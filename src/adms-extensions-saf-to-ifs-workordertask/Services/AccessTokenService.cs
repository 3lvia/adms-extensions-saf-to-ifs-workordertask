using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json.Linq;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;



namespace ServicesIfs
{
    public class AccessTokenService : IAccessTokenService
    {
        private readonly HttpClient _httpClient;
        private readonly IClientCredentialsConfiguration _config;
        private readonly IMemoryCache _memoryCache;

        private const string AccessTokenMemoryCacheKey = "AccessTokenMemoryCacheKey";

        public AccessTokenService(HttpClient httpClient, IClientCredentialsConfiguration config, IMemoryCache memoryCache)
        {
            _httpClient = httpClient;
            _config = config;
            _memoryCache = memoryCache;
        }     

        public async Task<string> GetAccessToken()
        {
            if (_memoryCache.TryGetValue(AccessTokenMemoryCacheKey, out string cachedAccessToken))
            {
                return cachedAccessToken;
            }

            HttpRequestMessage requestMessage = new HttpRequestMessage(HttpMethod.Post, _config.TokenEndpoint());

            SetHeaders(requestMessage.Headers);

            requestMessage.Content = new StringContent("grant_type=client_credentials&client_id=" + _config.ClientId() + "&client_secret=" + _config.ClientSecret() + "", Encoding.UTF8, "application/x-www-form-urlencoded");

            var svar = "";

            await _httpClient.SendAsync(requestMessage)
           .ContinueWith(async responseTask =>
           {
               Console.WriteLine("Response: {0}", responseTask.Result);
               var content = await responseTask.Result.Content.ReadAsStringAsync();
               svar = content;
           });
            JObject jObject = JObject.Parse(svar);

            string token = jObject["access_token"].Value<string>();

            double expires = jObject["expires_in"].Value<double>();

            var cacheEntryOptions = new MemoryCacheEntryOptions().SetAbsoluteExpiration(TimeSpan.FromSeconds(expires));
            _memoryCache.Set(AccessTokenMemoryCacheKey, token, cacheEntryOptions);

            //Temp
            Console.WriteLine("AccessToken fetched: "+ token.Substring(0,4));

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
