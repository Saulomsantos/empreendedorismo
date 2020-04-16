using System;
using System.Collections.Generic;

namespace empreendedorismov2.webapi.Domains
{
    public partial class CnpjDadosCadastraisPj
    {
        public int CodEmpresa { get; set; }
        public long? Cnpj { get; set; }
        public string RazaoSocial { get; set; }
        public int? SituacaoCadastral { get; set; }
        public int? CnaeFiscal { get; set; }
        public string DescricaoTipoLogradouro { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Cep { get; set; }
        public string Uf { get; set; }
        public string Municipio { get; set; }
        public string DddTelefone1 { get; set; }
        public string DddTelefone2 { get; set; }
        public string DddFax { get; set; }
        public string CorreioEletronico { get; set; }
        public string PorteEmpresa { get; set; }
        public string Lat { get; set; }
        public string Lng { get; set; }

        public TabCnae CnaeFiscalNavigation { get; set; }
        public TabSituacaoCadastral SituacaoCadastralNavigation { get; set; }
    }
}
