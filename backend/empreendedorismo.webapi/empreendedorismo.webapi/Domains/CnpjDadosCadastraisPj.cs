using System.ComponentModel.DataAnnotations;

namespace empreendedorismo.webapi.Domains
{
    /// <summary>
    /// Classe responsável pela entidade CNPJ Dados Cadastrais
    /// </summary>
    public partial class CnpjDadosCadastraisPj
    {
        public long Cnpj { get; set; }
        public string RazaoSocial { get; set; }
        public string NomeFantasia { get; set; }

        [Required(ErrorMessage = "Informe o CNAE. Ex: 4711302")]
        public int CnaeFiscal { get; set; }

        public int? SituacaoCadastral { get; set; }
        public string Bairro { get; set; }
        public string Uf { get; set; }
        public string Municipio { get; set; }

        public TabCnae CnaeFiscalNavigation { get; set; }
        public TabSituacaoCadastral SituacaoCadastralNavigation { get; set; }
    }
}
