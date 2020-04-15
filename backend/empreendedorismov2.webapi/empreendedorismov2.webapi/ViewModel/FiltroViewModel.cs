using System.ComponentModel.DataAnnotations;

namespace empreendedorismov2.webapi.ViewModel
{
    /// <summary>
    /// Classe responsável pelo modelo de filtro
    /// </summary>
    public class FiltroViewModel
    {
        [Required(ErrorMessage = "Informe o CNAE para pesquisa")]
        public int CnaeFiscal { get; set; }
        public string Bairro { get; set; }
        public string Municipio { get; set; }
    }
}
