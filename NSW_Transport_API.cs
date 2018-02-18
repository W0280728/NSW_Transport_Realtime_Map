using System;
using ProtoBuf;
using System.Net;
using transit_realtime;
using System.Configuration;
using System.Diagnostics;

namespace nsw_pt_map
{
    public class NSW_Transport_API
    {
        public static FeedMessage Get_Trains()
        {
            WebRequest req = HttpWebRequest.Create("https://api.transport.nsw.gov.au/v1/gtfs/vehiclepos/sydneytrains");
            req.Headers.Add(string.Format("Authorization:apikey {0}", System.Configuration.ConfigurationManager.AppSettings["NSWPublicTransportAPIKey"].ToString()));
            try
            {
                FeedMessage feed = Serializer.Deserialize<FeedMessage>(req.GetResponse().GetResponseStream());
                return feed;
            } catch (Exception e)
            {
                Debug.WriteLine(e);
                return new FeedMessage();
            }
        }

        public static FeedMessage Get_Ferries()
        {
            WebRequest req = HttpWebRequest.Create("https://api.transport.nsw.gov.au/v1/gtfs/vehiclepos/ferries");
            req.Headers.Add(string.Format("Authorization:apikey {0}", System.Configuration.ConfigurationManager.AppSettings["NSWPublicTransportAPIKey"].ToString()));
            try
            {
                FeedMessage feed = Serializer.Deserialize<FeedMessage>(req.GetResponse().GetResponseStream());
                return feed;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                return new FeedMessage();
            }
        }

        public static FeedMessage Get_Busses()
        {
            WebRequest req = HttpWebRequest.Create("https://api.transport.nsw.gov.au/v1/gtfs/vehiclepos/buses");
            req.Headers.Add(string.Format("Authorization:apikey {0}", System.Configuration.ConfigurationManager.AppSettings["NSWPublicTransportAPIKey"].ToString()));
            try
            {
                FeedMessage feed = Serializer.Deserialize<FeedMessage>(req.GetResponse().GetResponseStream());
                return feed;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                return new FeedMessage();
            }
        }
    }
}
