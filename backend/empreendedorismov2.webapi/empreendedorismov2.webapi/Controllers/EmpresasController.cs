using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using empreendedorismov2.webapi.Domains;
using empreendedorismov2.webapi.Interfaces;
using empreendedorismov2.webapi.Repositories;
using empreendedorismov2.webapi.ViewModel;
using Microsoft.AspNetCore.Http;
using System.Globalization;
using System.Text;
using empreendedorismov2.webapi.Util;

namespace empreendedorismov2.webapi.Controllers
{
    /// <summary>
    /// Controller responsável pelos endpoints referentes às empresas
    /// </summary>

    // Define que o tipo de resposta da API será no formato JSON
    [Produces("application/json")]

    // Define que a rota de uma requisição será no formato domínio/api/NomeController
    [Route("api/[controller]")]

    // Define que é um controlador de API
    [ApiController]
    public class EmpresasController : ControllerBase
    {
        /// <summary>
        /// Cria um objeto _empresasRepository que irá receber todos os métodos definidos na interface
        /// </summary>
        private IEmpresasRepository _empresasRepository;
        private IEnderecoRepository _enderecoRepository;
        private IGeolocation _locationRepository;

        /// <summary>
        /// Instancia este objeto para que haja a referência aos métodos no repositório
        /// </summary>
        public EmpresasController()
        {
            _empresasRepository = new EmpresasRepository();
            _enderecoRepository = new EnderecoRepository();
            _locationRepository = new GoogleMaps();
        }

        /// <summary>
        /// Lista todas as empresas do estado de SP em um determinado bairro e CNAE escolhidos (filtro)
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     {
        ///        "municipio" : "string",
        ///        "bairro": "string",
        ///        "cnae": number
        ///     }
        ///
        /// </remarks>
        /// <param name="filtro">Objeto com os filtros passados</param>
        /// <returns>Uma lista de empresas e um status code 200 - Ok</returns>
        /// <response code="200">Retorna a lista de empresas de um determinado município, bairro e CNAE</response>
        /// <response code="400">Retorna uma mensagem de erro personalizada</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetByCnaeDistrict(FiltroViewModel filtro)
        {
            StringBuilder sb = new StringBuilder();

            var arr = filtro.Bairro.Normalize(NormalizationForm.FormD).ToCharArray();

            foreach (char item in arr)
            {
                if (CharUnicodeInfo.GetUnicodeCategory(item) != UnicodeCategory.NonSpacingMark)
                {
                    sb.Append(item);
                }
            }

            filtro.Bairro = sb.ToString().ToLower();

            filtro.Municipio = filtro.Municipio.ToLower();

            if (filtro.CnaeFiscal > 0)
            {
                // Cria uma lista para armazenar as empresas buscadas
                List<CnpjDadosCadastraisPj> listaEmpresas = new List<CnpjDadosCadastraisPj>();

                // Busca todas as empresas que atendam ao filtro e armazena na lista
                listaEmpresas = _empresasRepository.ListByCnae(filtro);

                // Retora a resposta da requisição 200 - OK
                // trazendo a quantidade de empresas
                // e a lista de empresas
                return Ok(new
                {
                    qtdEmpresas = listaEmpresas.Count(),
                    listaEmpresas
                });
            }

            // Caso o bairro não seja informado, retorna a resposta da requisição 400 - BadRequest
            // e uma mensagem personalizada
            if (filtro.Bairro == null)
            {
                return BadRequest("Informe o Bairro para pesquisa sem acentuação. Ex: sao mateus");
            }

            // Caso o município não seja informado, retorna a resposta da requisição 400 - BadRequest
            // e uma mensagem personalizada
            if (filtro.Municipio == null)
            {
                return BadRequest("Informe o Município para pesquisa sem acentuação. Ex: sao paulo");
            }

            // Caso um código CNAE não seja informado, retorna a reposta da requisição 400 - BadRequest
            // e uma mensagem personalizada
            return BadRequest("Informe o CNAE para pesquisa. Ex: 4711302 ou 471");
        }

        /// <summary>
        /// Lista a quantidade de empresas de um determinado CNAE para o bairro informado
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     {
        ///        "bairro": "string"
        ///     }
        ///
        /// </remarks>
        /// <param name="filtro">Objeto com o bairro desejado</param>
        /// <returns>Uma lista de grupos (CNAE e quantidade de empresa) e um status code 200 - Ok</returns>
        /// <response code="200">Retorna a lista de grupos de um determinado bairro</response>
        [HttpPost("Group")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetByGroup(FiltroViewModel filtro)
        {
            return Ok(_empresasRepository.ListGroup(filtro));
        }

        //[HttpGet("location")]
        //public IActionResult getadress()
        //{
        //    //string param = "json?address=490+avenida+jose+lopez+lazaro,+presidente+altino,+osasco,+sp&key=AIzaSyB0L8qvc3w7RQ3RfAwDaoxx9RED3EFSSiE";

        //    string param = "json?address=06210030&key=AIzaSyBjvccU6EHuwQAdKAaGNIfbSH9LYeJ8DBk";

        //    var location = _enderecoRepository.GetLocation(param);

        //    return Ok(location);
        //}

        [ApiExplorerSettings(IgnoreApi = true)]
        [HttpPost("locationGmaps")]
        public IActionResult getAdress()
        {
            //var tempAdress = _locationRepository.BuscarPorEndereco(logradouro, numero, cidade, estado, sensor);

            _empresasRepository.AtualizaLatLng();

            return Ok();
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        [HttpGet("locationHere")]
        public IActionResult getAdressHere()
        {
            //AddressModel tempAddress = _empresasRepository.AtualizaLatLngHere();

            _empresasRepository.AtualizaLatLngHere();

            return Ok();
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        [HttpPut("locationRemoveCommaAddDot")]
        public IActionResult updateAddress()
        {
            _empresasRepository.RemoveCommaAddDot();

            return Ok();
        }
    }
}