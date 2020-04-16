using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace empreendedorismov2.webapi.Domains
{
    public class Endereco
    {
        [JsonProperty("lat")]
        public string lat { get; set; }

        [JsonProperty("lng")]
        public string lng { get; set; }
    }
}
