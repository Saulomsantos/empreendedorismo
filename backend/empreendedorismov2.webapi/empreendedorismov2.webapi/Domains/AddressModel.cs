using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace empreendedorismov2.webapi.Domains
{
    public class AddressModel
    {
        public AddressModel()
        {
            if (GeoCode == null)
                GeoCode = new GeoCodeModel();
        }

        public string Endereco { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string Pais { get; set; }
        public string Cep { get; set; }
        public string Formatted { get; set; }
        public GeoCodeModel GeoCode { get; set; }
    }
}
