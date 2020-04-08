using System.Collections.Generic;

namespace empreendedorismo.webapi.Domains
{
    /// <summary>
    /// Classe responsável pela entidade Situacao Cadastral
    /// </summary>
    public partial class TabSituacaoCadastral
    {
        public TabSituacaoCadastral()
        {
            CnpjDadosCadastraisPj = new HashSet<CnpjDadosCadastraisPj>();
        }

        public int CodSituacaoCadastral { get; set; }
        public string NmSituacaoCadastral { get; set; }

        public ICollection<CnpjDadosCadastraisPj> CnpjDadosCadastraisPj { get; set; }
    }
}
