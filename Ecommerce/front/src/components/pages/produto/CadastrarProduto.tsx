import { useState } from "react";
import Produto from "../../../models/Produto";
import { preconnect } from "react-dom";
import axios from "axios";

function CadastrarProduto(){
    const [nome, setNome] = useState("");
    const [quantidade, setQuantidade] = useState(0);
    const [preco, setPreco] = useState(0);

    function submeterForm(e : any){
        e.preventDefault();
        enviarProdutoAPI();
    }

    async function enviarProdutoAPI(){
        try{
        const produto : Produto = {
            nome,
            quantidade,
            preco, 
        };

        const resposta = await axios.post ("http://localhost:5279/api/produto/cadastrar", produto);
        console.log (resposta.data);
        }
        catch(error)
        {console.log("Erro ao cadastrar produto: " + error);}
        
    }

    return (
        <div>
            <h1>Cadastrar Produto</h1>
            <form onSubmit={submeterForm}>
                <div>
                    <label>Nome: </label>    
                    <input type="text" onChange={ (e : any) =>setNome(e.target.value)}required/>
                </div>
                <div>
                    <label>Preço: </label>
                    <input type="text" onChange={(e : any) =>setPreco(e.target.value)} required/>
                </div>
                <div>
                    <label>Quantidade: </label>
                    <input type="text" onChange={(e : any) =>setQuantidade(e.target.value)} required/>
                </div>
                <div>
                    <button type="submit">Cadastrar</button>
                </div>
            </form>
        </div>
    );

}

export default CadastrarProduto;