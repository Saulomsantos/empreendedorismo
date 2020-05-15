using empreendedorismov2.webapi.Domains;
using empreendedorismov2.webapi.Interfaces;
using Newtonsoft.Json.Linq;
using System;
using System.Net;

namespace empreendedorismov2.webapi.Util
{
    public class HereMaps : IGeolocation
    {
        public AddressModel BuscarPorEndereco(string logradouro, string numero, string cidade, string estado, bool sensor)
        {
            try
            {
                AddressModel tempAddress = null;

                using (var webClient = new WebClient())
                {
                    string url = string.Format("https://geocode.search.hereapi.com/v1/geocode?q={0}&apiKey=ik5cSBhbY4kYf912mlYI_YxZMt3wyBAPAfKtttG_ZUQ", string.Format("{0}, {1}, {2}, {3}", logradouro, numero, cidade, estado));

                    string json =
                        webClient.DownloadString(url);
                    // Now parse with JSON.Net

                    JObject o = JObject.Parse(json);

                    var jsongmaps = (JArray)o["items"];

                    if (jsongmaps.Count > 0)
                    {
                        tempAddress = new AddressModel();

                        tempAddress.GeoCode.Latitude = (jsongmaps.Count > 0 ?
                                                jsongmaps[0].SelectToken("position").SelectToken("lat").ToString()
                                                : null);

                        tempAddress.GeoCode.Longitude = (jsongmaps.Count > 0 ?
                                                jsongmaps[0].SelectToken("position").SelectToken("lng").ToString()
                                                : null);
                    }
                }

                return tempAddress;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
