using empreendedorismov2.webapi.Domains;
using empreendedorismov2.webapi.ViewModel;
using System.Collections.Generic;

namespace empreendedorismov2.webapi.Interfaces
{
    /// <summary>
    /// Interface responsável pelo EmpresasRepository
    /// </summary>
    interface IEmpresasRepository
    {
        /// <summary>
        /// Lista todas as empresas de um determinado município, bairro e CNAE escolhidos (filtro)
        /// </summary>
        /// <param name="filtro">Objeto com os filtros passados</param>
        /// <returns>Uma lista de empresas</returns>
        List<CnpjDadosCadastraisPj> ListByCnae(FiltroViewModel filtro);

        /// <summary>
        /// Lista a quantidade de empresas de um determinado CNAE para o bairro informado
        /// </summary>
        /// <param name="filtro">Objeto com o bairro desejado</param>
        /// <returns>Uma lista de grupos (CNAE e quantidade de empresa)</returns>
        List<GroupEmpresasViewModel> ListGroup(FiltroViewModel filtro);

        /// <summary>
        /// Atualiza os dados de Latitude e Longitude da empresa do Google
        /// </summary>
        void AtualizaLatLng();

        /// <summary>
        /// Atualiza os dados de Latitude e Longitude da empresa usando a API Map Here
        /// </summary>
        void AtualizaLatLngHere();
    }
}
