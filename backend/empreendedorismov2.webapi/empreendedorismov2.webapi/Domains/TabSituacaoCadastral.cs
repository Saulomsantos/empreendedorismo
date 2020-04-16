using System;
using System.Collections.Generic;

namespace empreendedorismov2.webapi.Domains
{
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
