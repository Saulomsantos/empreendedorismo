using System;
using System.Collections.Generic;

namespace empreendedorismov2.webapi.Domains
{
    public partial class CnpjDadosSociosPj
    {
        public int CodSocio { get; set; }
        public long? Cnpj { get; set; }
        public string IdentificadorSocio { get; set; }
        public string NomeSocio { get; set; }
        public string CnpjCpfSocio { get; set; }
    }
}
