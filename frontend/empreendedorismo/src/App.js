import React, { Component } from 'react';
import './App.css';
import Axios from 'axios';

class App extends Component {
  constructor(){
    super();
    this.state = {
      escolhaCnae : '',
      escolhaBairro : '',
      qtdEmpresas : 0,
      listaEmpresas : []
    }
  }

  atualizaEstado = (event) => {
    this.setState({ [event.target.name] : event.target.value })
  }

  formatarCnae = (event) => {
    this.atualizaEstado(event);
  }

  formatarBairro = (event) => {
    this.atualizaEstado(event);
  }

  buscar = async (e) => {
    e.preventDefault();

    await Axios.post('http://localhost:5000/api/Empresas/Bairro', {
      cnaeFiscal : this.state.escolhaCnae,
      bairro : this.state.escolhaBairro
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
          <div className="container">
            <select
              className="select-cnae"
              value={this.state.escolhaCnae}
              onChange={(c) => this.formatarCnae(c)}
              name="escolhaCnae"
            >
              <option>Selecione o CNAE</option>
              <option value="4711302">Comércio varejista de mercadorias em geral com predominância de produtos alimentícios - supermercados</option>
              <option value="4713004">Lojas de departamentos ou magazines exceto lojas francas (Duty free)</option>
              <option value="4712100">Comércio varejista de mercadorias em geral com predominância de produtos alimentícios - minimercados mercearias e armazéns</option>
            </select>

            <select
              className="select-bairro"
              value={this.state.escolhaBairro}
              onChange={(c) => this.formatarBairro(c)}
              name="escolhaBairro"
            >
              <option>Selecione o bairro</option>
              <option value="sao mateus">São Mateus</option>
              <option value="santa cecilia">Santa Cecília</option>
              <option value="santana">Santana</option>
            </select>

            <button onClick={this.buscar}>Buscar</button>
          </div>

          {/* Lista de empresas */}

          <div className="empresasLista">
            {this.state.qtdEmpresas > 0 ? <h2>Lista de empresas | Total: {this.state.qtdEmpresas}</h2> : <h2>Lista de empresas</h2>}
              
                <table className="empresasLista__table">
                    <thead className="empresasLista__table--header">
                        <tr>
                            <th className="th-CNPJ">CNPJ</th>
                            <th>Razão Social</th>
                        </tr>
                    </thead>

                    <tbody className="empresasLista__table--body">
                        {
                          this.state.listaEmpresas.map(function(empresa) {
                              return (
                                  <tr key={empresa.cnpj}>
                                      <td className="td-CNPJ">{empresa.cnpj}</td>
                                      <td>{empresa.razaoSocial}</td>
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