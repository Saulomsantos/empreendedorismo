using System.Collections.Generic;

namespace empreendedorismo.webapi.Domains
{
    /// <summary>
    /// Classe responável pela entidade CNAE
    /// </summary>
    public partial class TabCnae
    {
        public TabCnae()
        {
            CnpjDadosCadastraisPj = new HashSet<CnpjDadosCadastraisPj>();
        }

        public int CodCnae { get; set; }
        public string NmCnae { get; set; }

        public ICollection<CnpjDadosCadastraisPj> CnpjDadosCadastraisPj { get; set; }
    }
}
