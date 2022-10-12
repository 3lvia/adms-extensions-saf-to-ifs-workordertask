using Elvia.KvalitetsportalLogger;
using Elvia.Telemetry;
using Newtonsoft.Json;
using ServicesIfs;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Channels;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SafToSesamAPI.Services
{

    public class IfsService : IIfsService
    {
        //private readonly IConveyPublisher _conveyPublisher;

        //public IAccessTokenService _accessTokenService { get; }

        public IAccessTokenService _accessTokenService { get; }

        public IfsService(IAccessTokenService accessTokenService)
        {
            _accessTokenService = accessTokenService;
        }


        public string Post()
        {









            return "";
        }




        //public string Post(CustomerNotificationResponseDto conveyRequest, string safRequest)
        //{

        //    var typeMld = conveyRequest.Payload[0].NotificationData.NotificationType;


        //    var jobObjects = MapToConveyJobs(conveyRequest);

        //    string conveyMessage = JsonConvert.SerializeObject(jobObjects, Newtonsoft.Json.Formatting.Indented);

        //    try
        //    {
        //        InvokeConvey(jobObjects);
        //    }
        //    catch (Exception ex)
        //    {

        //        Thread.Sleep(1 * 60 * 1000); // every 5 min
        //        throw new Exception("ERROR Service " + ex.Message);
        //    }

        //    return conveyMessage;
        //}

        //private void InvokeConvey(List<BroadcastJobDto> request)
        //{
        //    try
        //    {
        //        Task t = _conveyPublisher.Publish(request);
        //        t.Wait();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message);
        //    }
        //    //catch (AggregateException ae)
        //    //{
        //    //    throw ae.InnerException;
        //    //}
        //}



        private static DateTime ConvertToNorwegianTimeZone(DateTime dateTimeUTC)
        {
            var timeZoneId = "Europe/Oslo";
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                timeZoneId = "W. Europe Standard Time";
            }
            var norwegianTimeZone = TimeZoneInfo.FindSystemTimeZoneById(timeZoneId);
            var _dateTimeUTC = DateTime.SpecifyKind(dateTimeUTC, DateTimeKind.Utc);


            DateTime norwegianDateTime = TimeZoneInfo.ConvertTimeFromUtc(_dateTimeUTC, norwegianTimeZone);
            return norwegianDateTime;
        }


        private string ConvertDate(DateTime dt)
        {
            dt = ConvertToNorwegianTimeZone(dt);

            var tmp = dt.ToString("dd.MM.yyyy") + "  kl. " + dt.ToString("HH:mm").Replace(".", ":");
            return tmp;
        }

       


   



        //private static string Serialize(object o)
        //{
        //    if (o == null) return string.Empty;

        //    using (var writer = new StringWriter())
        //    {
        //        new XmlSerializer(o.GetType()).Serialize(writer, o);
        //        return writer.ToString();
        //    }
        //}

    }
}
