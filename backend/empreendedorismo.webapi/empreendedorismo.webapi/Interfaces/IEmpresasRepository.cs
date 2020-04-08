using empreendedorismo.webapi.Domains;
using empreendedorismo.webapi.ViewModel;
using System.Collections.Generic;

namespace empreendedorismo.webapi.Interfaces
{
    /// <summary>
    /// Interface responsável pelo EmpresasRepository
    /// </summary>
    interface IEmpresasRepository
    {
        /// <summary>
        /// Lista todas as empresas de SP de um determinado município e CNAE escolhidos (filtro)
        /// </summary>
        /// <param name="filtro">Objeto com os filtros passados</param>
        /// <returns>Uma lista de empresas</returns>
        List<CnpjDadosCadastraisPj> ListarByCnaeCity(FiltroViewModel filtro);

        /// <summary>
        /// Lista todas as empresas de SP de um determinado bairro e CNAE escolhidos (filtro)
        /// </summary>
        /// <param name="filtro">Objeto com os filtros passados</param>
        /// <returns>Uma lista de empresas</returns>
        List<CnpjDadosCadastraisPj> ListarByCnaeDistrict(FiltroViewModel filtro);
    }
}
