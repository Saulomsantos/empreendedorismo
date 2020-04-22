using empreendedorismov2.webapi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace empreendedorismov2.webapi.Interfaces
{
    interface IGeolocation
    {
        AddressModel BuscarPorEndereco(string logradouro, string numero, string cidade, string estado, bool sensor);
    }
}
