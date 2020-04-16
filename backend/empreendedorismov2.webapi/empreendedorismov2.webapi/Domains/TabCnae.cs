using System;
using System.Collections.Generic;

namespace empreendedorismov2.webapi.Domains
{
    public partial class TabCnae
    {
        public TabCnae()
        {
            CnpjDadosCadastraisPj = new HashSet<CnpjDadosCadastraisPj>();
        }

        public string CodSecao { get; set; }
        public string NmSecao { get; set; }
        public string CodDivisao { get; set; }
        public string NmDivisao { get; set; }
        public string CodGrupo { get; set; }
        public string NmGrupo { get; set; }
        public string CodClasse { get; set; }
        public string NmClasse { get; set; }
        public int CodCnae { get; set; }
        public string NmCnae { get; set; }

        public ICollection<CnpjDadosCadastraisPj> CnpjDadosCadastraisPj { get; set; }
    }
}
