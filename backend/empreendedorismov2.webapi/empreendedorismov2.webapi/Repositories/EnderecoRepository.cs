using empreendedorismov2.webapi.Domains;
using empreendedorismov2.webapi.Interfaces;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace empreendedorismov2.webapi.Repositories
{
    public class EnderecoRepository : IEnderecoRepository
    {
        public async Task<Endereco> GetLocation(string param)
        {
            var googleAPI = RestService.For<IEnderecoRepository>("https://maps.googleapis.com/");
            var enderecoRetornado = await googleAPI.GetLocation(param);

            return enderecoRetornado;
        }
    }
}
