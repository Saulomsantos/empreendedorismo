using System;
using System.Collections.Generic;
using empreendedorismov2.webapi.Domains;
using empreendedorismov2.webapi.Interfaces;
using empreendedorismov2.webapi.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace empreendedorismov2.webapi.Controllers
{
    /// <summary>
    /// Controller responsável pelos endpoints referentes aos CNAEs
    /// </summary>

    // Define que o tipo de resposta da API será no formato JSON
    [Produces("application/json")]

    // Define que a rota de uma requisição será no formato domínio/api/NomeController
    [Route("api/[controller]")]

    // Define que é um controlador de API
    [ApiController]
    public class CnaesController : ControllerBase
    {
        /// <summary>
        /// Cria um objeto _empresasRepository que irá receber todos os métodos definidos na interface
        /// </summary>
        private ICnaesRepository _cnaesRepository;

        /// <summary>
        /// Instancia este objeto para que haja a referência aos métodos no repositório
        /// </summary>
        public CnaesController()
        {
            _cnaesRepository = new CnaesRepository();
        }

        /// <summary>
        /// Lista todos os CNAEs
        /// </summary>
        /// <returns>Uma lista de CNAEs e um status code 200 - Ok</returns>
        /// <response code="200">Retorna a lista de CNAEs</response>
        /// <response code="400">Retorna uma mensagem de erro</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetCnaes()
        {
            try
            {
                // Cria uma lista para armazenar os CNAEs buscados
                List<TabCnae> listaCnaes = new List<TabCnae>();

                // Busca todos os CNAEs e armazena na lista
                listaCnaes = _cnaesRepository.ListCnae();

                // Retora a resposta da requisição 200 - OK trazendo a lista de CNAEs
                return Ok(listaCnaes);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}