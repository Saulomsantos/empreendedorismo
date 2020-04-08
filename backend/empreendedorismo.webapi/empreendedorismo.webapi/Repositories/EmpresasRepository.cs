using empreendedorismo.webapi.Contexts;
using empreendedorismo.webapi.Domains;
using empreendedorismo.webapi.Interfaces;
using empreendedorismo.webapi.ViewModel;
using System.Collections.Generic;
using System.Linq;

namespace empreendedorismo.webapi.Repositories
{
    /// <summary>
    /// Classe responsável pelo repositório das empresas
    /// </summary>
    public class EmpresasRepository : IEmpresasRepository
    {
        /// <summary>
        /// Instancia um contexto para chamada dos métodos do EF Core
        /// </summary>
        EmpreendedorismoContext ctx = new EmpreendedorismoContext();

        /// <summary>
        /// Lista todas as empresas de SP de um determinado município e CNAE escolhidos (filtro)
        /// </summary>
        /// <param name="filtro">Objeto com os filtros passados</param>
        /// <returns>Uma lista de empresas</returns>
        public List<CnpjDadosCadastraisPj> ListarByCnaeCity(FiltroViewModel filtro)
        {
            return ctx.CnpjDadosCadastraisPj
                .Select(e => new CnpjDadosCadastraisPj()
                {
                    Cnpj = e.Cnpj,
                    RazaoSocial = e.RazaoSocial,
                    NomeFantasia = e.NomeFantasia,
                    CnaeFiscal = e.CnaeFiscal,
                    Municipio = e.Municipio,
                    CnaeFiscalNavigation = new TabCnae()
                    {
                        NmCnae = e.CnaeFiscalNavigation.NmCnae
                    }
                })
                .Where(e => e.CnaeFiscal == filtro.CnaeFiscal && e.Municipio == filtro.Municipio)
                .ToList();

            //foreach (var item in listaEmpresas)
            //{
            //    item.CnaeFiscalNavigation.CnpjDadosCadastraisPj = null;
            //}

            //return listaEmpresas;
        }

        /// <summary>
        /// Lista todas as empresas de SP de um determinado bairro e CNAE escolhidos (filtro)
        /// </summary>
        /// <param name="filtro">Objeto com os filtros passados</param>
        /// <returns>Uma lista de empresas</returns>
        public List<CnpjDadosCadastraisPj> ListarByCnaeDistrict(FiltroViewModel filtro)
        {
            return ctx.CnpjDadosCadastraisPj
                .Select(e => new CnpjDadosCadastraisPj()
                {
                    Cnpj = e.Cnpj,
                    RazaoSocial = e.RazaoSocial,
                    NomeFantasia = e.NomeFantasia,
                    CnaeFiscal = e.CnaeFiscal,
                    Bairro = e.Bairro,
                    CnaeFiscalNavigation = new TabCnae()
                    {
                        NmCnae = e.CnaeFiscalNavigation.NmCnae
                    }
                })
                .Where(e => e.CnaeFiscal == filtro.CnaeFiscal && e.Bairro == filtro.Bairro)
                .ToList();
        }
    }
}
