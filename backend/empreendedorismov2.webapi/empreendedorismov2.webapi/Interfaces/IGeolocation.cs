using empreendedorismov2.webapi.Domains;

namespace empreendedorismov2.webapi.Interfaces
{
    interface IGeolocation
    {
        AddressModel BuscarPorEndereco(string logradouro, string numero, string cidade, string estado, bool sensor);
    }
}
