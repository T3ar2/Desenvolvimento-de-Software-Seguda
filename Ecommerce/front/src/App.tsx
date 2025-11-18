import React from 'react';
import logo from './logo.svg';
import './App.css';
import CadastrarProduto from './components/pages/produto/CadastrarProduto';
import ListarProduto from './components/pages/produto/ListarProduto';
import { BrowserRouter, Route, Routes } from 'react-router-dom';
import { Link } from 'react-router-dom';
import AlterarProduto from './components/pages/produto/AlterarProduto';

function App() {
  return (
    <div id="componente_app">
      <BrowserRouter>
      <nav>
        <ul>
          <li><Link to="/">Listar Produtos</Link></li>
          <li>
            <Link to="/pages/produto/cadastrar">Cadastrat Produtos</Link>
          </li>
        </ul>
      </nav>
      <div id="Conteudo">
        <Routes>
          <Route path="/produto/listar" element={<ListarProduto/>}/>
          <Route path="/produto/cadastrar" element={<CadastrarProduto/>}/>
          <Route path="/produto/alterar/:id" element={<AlterarProduto/>}/>
        </Routes>
      </div>
      <footer>

      </footer>
      </BrowserRouter>
    </div>
  );
}

export default App;
