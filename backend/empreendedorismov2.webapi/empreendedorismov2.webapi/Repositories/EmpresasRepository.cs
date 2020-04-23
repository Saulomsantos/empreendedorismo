﻿using empreendedorismov2.webapi.Domains;
using empreendedorismov2.webapi.Interfaces;
using empreendedorismov2.webapi.Util;
using empreendedorismov2.webapi.ViewModel;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace empreendedorismov2.webapi.Repositories
{
    /// <summary>
    /// Classe responsável pelo repositório das empresas
    /// </summary>
    public class EmpresasRepository : IEmpresasRepository
    {
        /// <summary>
        /// Instancia um contexto para chamada dos métodos do EF Core
        /// </summary>
        EmpContext ctx = new EmpContext();

        private IGeolocation _locationRepository = new GoogleMaps();

        /// <summary>
        /// Atualiza os dados de Latitude e Longitude da empresa
        /// </summary>
        public void AtualizaLatLng()
        {
            List<CnpjDadosCadastraisPj> listaEmpresas = ctx.CnpjDadosCadastraisPj
                .Where(e => e.SituacaoCadastral == 2 && e.CodEmpresa >= 1000 && e.CodEmpresa <= 1700)
                .ToList();

            string cidade = "sao paulo";

            string estado = "sp";

            bool sensor = true;

            for (int i = 1001; i <= 1700; i++)
            {
                CnpjDadosCadastraisPj empresaBuscada = listaEmpresas.Find(e => e.CodEmpresa == i);

                string logradouro = empresaBuscada.Logradouro;
                string numero = empresaBuscada.Numero;

                var tempAdress = _locationRepository.BuscarPorEndereco(logradouro, numero, cidade, estado, sensor);

                empresaBuscada.Lat = tempAdress.GeoCode.Latitude;
                empresaBuscada.Lng = tempAdress.GeoCode.Longitude;

                ctx.CnpjDadosCadastraisPj.Update(empresaBuscada);
                ctx.SaveChanges();
            }
        }

        /// <summary>
        /// Lista todas as empresas de SP de um determinado bairro e CNAE escolhidos (filtro)
        /// </summary>
        /// <param name="filtro">Objeto com os filtros passados</param>
        /// <returns>Uma lista de empresas</returns>
        public List<CnpjDadosCadastraisPj> ListByCnae(FiltroViewModel filtro)
        {
            return ctx.CnpjDadosCadastraisPj
                .Select(e => new CnpjDadosCadastraisPj()
                {
                    Cnpj = e.Cnpj,
                    RazaoSocial = e.RazaoSocial,
                    SituacaoCadastral = e.SituacaoCadastral,
                    CnaeFiscal = e.CnaeFiscal,
                    DescricaoTipoLogradouro = e.DescricaoTipoLogradouro,
                    Logradouro = e.Logradouro,
                    Numero = e.Numero,
                    Complemento = e.Complemento,
                    Bairro = e.Bairro,
                    Cep = e.Cep,
                    Uf = e.Uf,
                    Municipio = e.Municipio,
                    DddTelefone1 = e.DddTelefone1,
                    DddTelefone2 = e.DddTelefone2,
                    DddFax = e.DddFax,
                    CorreioEletronico = e.CorreioEletronico,
                    PorteEmpresa = e.PorteEmpresa,
                    Lat = e.Lat,
                    Lng = e.Lng,
                    

                    CnaeFiscalNavigation = new TabCnae()
                    {
                        NmCnae = e.CnaeFiscalNavigation.NmCnae
                    },

                    SituacaoCadastralNavigation = new TabSituacaoCadastral()
                    {
                        NmSituacaoCadastral = e.SituacaoCadastralNavigation.NmSituacaoCadastral
                    }
                })
                .Where(e => e.CnaeFiscal.ToString().StartsWith(filtro.CnaeFiscal.ToString()) 
                        && e.Bairro.StartsWith(filtro.Bairro)
                        && e.SituacaoCadastral == 2)
                .ToList();
        }

        /// <summary>
        /// Lista a quantidade de empresas de um determinado CNAE para o bairro informado
        /// </summary>
        /// <param name="filtro">Objeto com o bairro desejado</param>
        /// <returns>Uma lista de grupos (CNAE e quantidade de empresa)</returns>
        public List<GroupEmpresasViewModel> ListGroup(FiltroViewModel filtro)
        {
            List<GroupEmpresasViewModel> listaAgrupada = new List<GroupEmpresasViewModel>();

            List<CnpjDadosCadastraisPj> listaEmpresas = new List<CnpjDadosCadastraisPj>();

            listaEmpresas = ctx.CnpjDadosCadastraisPj
                .Where(e => e.Bairro.StartsWith(filtro.Bairro) && e.SituacaoCadastral == 2)
                .Include(e => e.CnaeFiscalNavigation)
                .ToList();

            var listaCnaes =
                from empresa in listaEmpresas
                group empresa by empresa.CnaeFiscal into newGroup
                orderby newGroup.Key
                select newGroup;

            foreach (var listaEmpresasPorCnae in listaCnaes)
            {
                GroupEmpresasViewModel novoGrupo = new GroupEmpresasViewModel();

                foreach (var item in listaEmpresasPorCnae)
                {
                    novoGrupo.cnae = item.CnaeFiscal;
                    novoGrupo.nmCnae = item.CnaeFiscalNavigation.NmCnae;
                    novoGrupo.qtdEmpresas = listaEmpresasPorCnae.Count();
                }

                listaAgrupada.Add(novoGrupo);
            }

            return listaAgrupada;
        }
    }
}
