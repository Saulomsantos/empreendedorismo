using empreendedorismov2.webapi.Domains;
using System.Collections.Generic;

namespace empreendedorismov2.webapi.Interfaces
{
    /// <summary>
    /// Interface responsável pelo CnaesRepository
    /// </summary>
    interface ICnaesRepository
    {
        /// <summary>
        /// Lista todos os CNAEs
        /// </summary>
        /// <returns>Uma lista de CNAEs</returns>
        List<TabCnae> ListCnae();
    }
}
