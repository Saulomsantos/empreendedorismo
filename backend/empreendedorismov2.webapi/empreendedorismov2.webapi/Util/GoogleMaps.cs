using empreendedorismov2.webapi.Domains;
using empreendedorismov2.webapi.Interfaces;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace empreendedorismov2.webapi.Util
{
    public class GoogleMaps : IGeolocation
    {
        public AddressModel BuscarPorEndereco(string logradouro, string numero, string cidade, string estado, bool sensor)
        {
            try
            {
                AddressModel tempAddress = null;

                using (var webClient = new WebClient())
                {
                    string url = string.Format("https://maps.googleapis.com/maps/api/geocode/json?key=AIzaSyB0L8qvc3w7RQ3RfAwDaoxx9RED3EFSSiE&address={0}&sensor={1}", string.Format("{0}, {1}, {2}, {3}", logradouro, numero, cidade, estado), sensor);

                    string json =
                        webClient.DownloadString(url);
                    // Now parse with JSON.Net

                    JObject o = JObject.Parse(json);

                    var jsongmaps = (JArray)o["results"];

                    if (jsongmaps.Count > 0)
                    {
                        tempAddress = new AddressModel();

                        var jsonAddress = (JArray)jsongmaps[0].SelectToken("address_components");

                        foreach (JToken t in jsonAddress)
                        {
                            string tipo = t.SelectToken("types").Values().Contains("sublocality") ? "sublocality" : t.SelectToken("types")[0].ToString();


                            switch (tipo)
                            {
                                case "route":
                                    {
                                        tempAddress.Endereco = t.SelectToken("long_name").ToString();
                                        break;
                                    }
                                case "sublocality":
                                    {
                                        tempAddress.Bairro = t.SelectToken("long_name").ToString();
                                        break;
                                    }
                                case "administrative_area_level_4":
                                    {
                                        tempAddress.Bairro = t.SelectToken("long_name").ToString();
                                        break;
                                    }
                                case "locality":
                                    {
                                        tempAddress.Cidade = t.SelectToken("long_name").ToString();
                                        break;
                                    }
                                case "administrative_area_level_1":
                                    {
                                        tempAddress.Estado = t.SelectToken("long_name").ToString();
                                        break;
                                    }
                                case "country":
                                    {
                                        tempAddress.Pais = t.SelectToken("long_name").ToString();
                                        break;
                                    }
                                case "postal_code":
                                    {
                                        tempAddress.Cep = t.SelectToken("long_name").ToString();
                                        break;
                                    }
                            }
                        }

                        tempAddress.GeoCode.Latitude = (jsongmaps.Count > 0
                                                            ? jsongmaps[0].SelectToken("geometry").SelectToken(
                                                                "location").SelectToken("lat").ToString()
                                                            : null);
                        tempAddress.GeoCode.Longitude = (jsongmaps.Count > 0
                                                             ? jsongmaps[0].SelectToken("geometry").SelectToken(
                                                                 "location").SelectToken("lng").ToString()
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
