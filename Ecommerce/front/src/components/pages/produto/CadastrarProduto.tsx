import { useState } from "react";
import Produto from "../../../models/Produto";
import { preconnect } from "react-dom";

function CadastrarProduto(){
    const [nome, setNome] = useState("");
    const [quantidade, setQuantidade] = useState(0);
    const [preco, setPreco] = useState(0);

    function submeterForm(e : any){
        e.preventDefault();
        enviarProdutoAPI();
    }

    async function enviarProdutoAPI(){
        const produto : Produto = {
            nome : nome,
            quantidade: quantidade,
            preco : preco, 
        };

        const resposta = await fetch("http://localhost:5279/api/produto/cadastrar", 
            {
                method : "POST",
                headers : {
                    "Content-Type" : "application/json"
                },
                body : JSON.stringify(produto)
            }
        )
        console.log(resposta)
    }

    function escreverTxtNome(e: any){
        setNome(e.target.value);
    }
    function escreverTxtQuantidade(e: any){
        setQuantidade(e.target.value);
    }
    function escreverTxtPreco(e: any){
        setPreco(e.target.value);
    }

    return (
        <div>
            <h1>Cadastrar Produto</h1>
            <form onSubmit={submeterForm}>
                <div>
                    <label>Nome: </label>
                    <input type="text" onChange={escreverTxtNome}required/>
                </div>
                <div>
                    <label>Quantidade: </label>
                    <input type="text" onChange={escreverTxtQuantidade} required/>
                </div>
                <div>
                    <label>Preço: </label>
                    <input type="text" onChange={escreverTxtPreco} required/>
                </div>
                <div>
                    <button type="submit">Cadastrar</button>
                </div>
            </form>
        </div>
    );

}

export default CadastrarProduto;