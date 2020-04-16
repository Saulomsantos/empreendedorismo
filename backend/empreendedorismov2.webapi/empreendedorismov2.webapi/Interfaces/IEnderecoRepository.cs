using empreendedorismov2.webapi.Domains;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace empreendedorismov2.webapi.Interfaces
{
    public interface IEnderecoRepository
    {
        [Get("/maps/api/geocode/{param}")]
        Task <Endereco> GetLocation(string param);
    }
}
