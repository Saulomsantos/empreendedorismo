using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using empreendedorismo.webapi.Domains;
using empreendedorismo.webapi.Interfaces;
using empreendedorismo.webapi.Repositories;
using empreendedorismo.webapi.ViewModel;
using Microsoft.AspNetCore.Http;

namespace empreendedorismo.webapi.Controllers
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

        /// <summary>
        /// Instancia este objeto para que haja a referência aos métodos no repositório
        /// </summary>
        public EmpresasController()
        {
            _empresasRepository = new EmpresasRepository();
        }

        /// <summary>
        /// Lista todas as empresas do estado de SP de um determinado município e CNAE escolhidos (filtro)
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     {
        ///        "cnae": number,
        ///        "municipio": "string"
        ///     }
        ///
        /// </remarks>
        /// <param name="filtro">Objeto com os filtros passados</param>
        /// <returns>Uma lista de empresas e um status code 200 - Ok</returns>
        /// <response code="200">Retorna a lista de empresas de um determinado município e CNAE</response>
        [HttpPost("Municipio")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetByCnaeCity(FiltroViewModel filtro)
        {
            if (filtro.CnaeFiscal > 0)
            {
                // Cria uma lista para armazenar as empresas buscadas
                List<CnpjDadosCadastraisPj> listaEmpresas = new List<CnpjDadosCadastraisPj>();

                // Busca todas as empresas que atendam ao filtro e armazena na lista
                listaEmpresas = _empresasRepository.ListarByCnaeCity(filtro);

                // Retora a resposta da requisição 200 - OK
                // trazendo a quantidade de empresas
                // e a lista de empresas
                return Ok(new
                {
                    qtdEmpresas = listaEmpresas.Count(),
                    listaEmpresas
                });
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
        /// Lista todas as empresas do estado de SP em um determinado bairro e CNAE escolhidos (filtro)
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     {
        ///        "cnae": number,
        ///        "bairro": "string"
        ///     }
        ///
        /// </remarks>
        /// <param name="filtro">Objeto com os filtros passados</param>
        /// <returns>Uma lista de empresas e um status code 200 - Ok</returns>
        /// <response code="200">Retorna a lista de empresas de um determinado bairro e CNAE</response>
        [HttpPost("Bairro")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetByCnaeDistrict(FiltroViewModel filtro)
        {
            if (filtro.CnaeFiscal > 0)
            {
                // Cria uma lista para armazenar as empresas buscadas
                List<CnpjDadosCadastraisPj> listaEmpresas = new List<CnpjDadosCadastraisPj>();

                // Busca todas as empresas que atendam ao filtro e armazena na lista
                listaEmpresas = _empresasRepository.ListarByCnaeDistrict(filtro);

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

            // Caso um código CNAE não seja informado, retorna a reposta da requisição 400 - BadRequest
            // e uma mensagem personalizada
            return BadRequest("Informe o CNAE para pesquisa. Ex: 4711302 ou 471");
        }
    }
}