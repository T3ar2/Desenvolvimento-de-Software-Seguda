import React from 'react';
import logo from './logo.svg';
import './App.css';
import CadastrarProduto from './components/pages/produto/CadastrarProduto';
import ListarProduto from './components/pages/produto/ListarProduto';

function App() {
  return (
    <div id="componente_app">
      <ListarProduto />
      <CadastrarProduto />
    </div>
  );
}

export default App;
