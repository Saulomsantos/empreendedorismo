import React, { Component } from 'react';
import './App.css';
import Axios from 'axios';

class App extends Component {
  constructor(){
    super();
    this.state = {
      escolhaMunicipio : '',
      escolhaBairro : '',
      escolhaCnae : '',
      qtdEmpresas : 0,
      listaMunicipio : [],
      listaBairro : [],
      listaCnae : [],
      listaEmpresas : []
    }
  }

  atualizaEstado = (event) => {
    this.setState({ [event.target.name] : event.target.value })
  }

  formatarMunicipio = (event) => {
    this.atualizaEstado(event);
    this.buscarBairroIbege(event.target.value);
  }

  formatarBairro = (event) => {
    this.atualizaEstado(event);
  }

  formatarCnae = (event) => {
    this.atualizaEstado(event);
  }

  buscarBairroIbege = async (e) =>{
    // console.log(e);
    const url = `https://servicodados.ibge.gov.br/api/v1/localidades/municipios/${e}/distritos`;
    // console.log(url);
    await Axios.get(url)
    .then(data => this.setState({
      listaBairro : data.data
    }))
    .catch((erro) => console.log(erro))

    // console.log(this.state.listaBairro);
  }

  buscarCnae = async () => {
    await Axios.get('http://localhost:5000/api/Cnaes')
    .then(data => this.setState({
      listaCnae : data.data
    }))
    .catch((erro) => console.log(erro))

    // console.log(this.state.listaCnae);
  }

  componentDidMount(){
    this.buscarCnae();
  }

  buscarEmpresas = async (e) => {
    e.preventDefault();

    this.setState ({ escolhaMunicipio : 'sao paulo' });
    this.setState ({ listaEmpresas : [] });
    this.setState ({ qtdEmpresas : 0 });

    await Axios.post('http://localhost:5000/api/Empresas', {
      municipio : this.state.escolhaMunicipio,
      bairro : this.state.escolhaBairro,
      cnaeFiscal : this.state.escolhaCnae
    })
      .then(data => this.setState({
        listaEmpresas : data.data.listaEmpresas,
        qtdEmpresas : data.data.qtdEmpresas
      }))
      .catch((erro) => console.log(erro))

      console.log(this.state.listaEmpresas)
  }

  render() {
    return (
      <div className="App">
        <main className="App-header">
          <div className="containerBusca">

            <select
              className="select-municipio"
              value={this.state.escolhaMunicipio}
              onChange={(m) => this.formatarMunicipio(m)}
              name="escolhaMunicipio"
            >
              <option>Selecione o município</option>
              <option value="3550308">São Paulo</option>
            </select>

            <select
              className="select-bairro"
              value={this.state.escolhaBairro}
              onChange={(b) => this.formatarBairro(b)}
              name="escolhaBairro"
            >
              <option>Selecione o bairro</option>
              {
                this.state.listaBairro.map((bairro) => {
                return <option key={bairro.id} value={bairro.nome}>{bairro.nome}</option>
                })
              }
            </select>

            <select
              className="select-cnae"
              value={this.state.escolhaCnae}
              onChange={(c) => this.formatarCnae(c)}
              name="escolhaCnae"
            >
              <option>Selecione o CNAE</option>
              {
                this.state.listaCnae.map((cnae) => {
                return <option key={cnae.codCnae} value={cnae.codCnae}>{cnae.nmCnae}</option>
                })
              }
            </select>

           

            <button onClick={this.buscarEmpresas}>Buscar</button>
          </div>

          {/* Lista de empresas */}

          <div className="empresasLista">
            {this.state.qtdEmpresas > 0 ? <h2>Lista de empresas | Total: {this.state.qtdEmpresas}</h2> : <h2>Lista de empresas</h2>}
              
                <table className="empresasLista__table">
                    <thead className="empresasLista__table--header">
                        <tr>
                            <th className="th-CNPJ">CNPJ</th>
                            <th>Razão Social</th>
                            <th>Situação Cadastral</th>
                            <th>Porte</th>
                            <th>Tipo de logradouro</th>
                            <th>Logradouro</th>
                            <th>Número</th>
                            <th>Complemento</th>
                            <th>Telefone 1</th>
                            <th>Telefone 2</th>
                            <th>Fax</th>
                            <th>E-mail</th>
                        </tr>
                    </thead>

                    <tbody className="empresasLista__table--body">
                        {
                          this.state.listaEmpresas.map(function(empresa) {
                              return (
                                  <tr key={empresa.cnpj}>
                                      <td className="td-CNPJ">{empresa.cnpj}</td>
                                      <td>{empresa.razaoSocial}</td>
                                      <td>{empresa.situacaoCadastralNavigation.nmSituacaoCadastral}</td>
                                      <td>{empresa.porteEmpresa}</td>
                                      <td>{empresa.tipo_logradouro}</td>
                                      <td>{empresa.logradouro}</td>
                                      <td>{empresa.numero}</td>
                                      <td>{empresa.complemento}</td>
                                      <td>{empresa.dddTelefone1}</td>
                                      <td>{empresa.dddTelefone2}</td>
                                      <td>{empresa.dddTelefoneFax}</td>
                                      <td>{empresa.correioEletronico}</td>

                                  </tr>
                              );
                          })
                        }
                    </tbody>
                </table>
            </div>
        </main>
      </div>
    );
  }
}

export default App;