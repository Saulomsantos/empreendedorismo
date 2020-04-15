using empreendedorismov2.webapi.Domains;
using empreendedorismov2.webapi.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace empreendedorismov2.webapi.Repositories
{
    /// <summary>
    /// Classe responsável pelo repositório dos CNAEs
    /// </summary>
    public class CnaesRepository : ICnaesRepository
    {
        /// <summary>
        /// Instancia um contexto para chamada dos métodos do EF Core
        /// </summary>
        EmpContext ctx = new EmpContext();

        /// <summary>
        /// Lista todos os CNAEs
        /// </summary>
        /// <returns>Uma lista de CNAEs</returns>
        public List<TabCnae> ListCnae()
        {
            return ctx.TabCnae.ToList();
        }
    }
}
