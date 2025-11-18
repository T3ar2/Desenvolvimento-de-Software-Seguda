import { useEffect, useState } from "react";
import Produto from "../../../models/Produto";
import { preconnect } from "react-dom";
import axios from "axios";
import { useNavigate, useParams } from "react-router-dom";

function AlterarProduto(){
    const url = useParams();
    const [nome, setNome] = useState("");
    const [quantidade, setQuantidade] = useState(0);
    const [preco, setPreco] = useState(0);
    const navegator = useNavigate();

    useEffect(() => {
        buscarProduto();
    }, []);

    async function buscarProduto() {
        try{
            const resposta = await axios.get<Produto>(`http://localhost:5279/api/produto/buscar/${id}`);
            setNome(resposta.data.nome);
            setPreco(resposta.data.preco);
            setQuantidade(resposta.data.quantidade)
        }
        catch(error){
            console.log(error);
        }
    }

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

        const resposta = await axios.patch (`http://localhost:5279/api/produto/alterar/${produto.id}`, produto);
        console.log (resposta.data);
        }
        catch(error)
        {console.log("Erro ao cadastrar produto: " + error);}
        
    }

    return (
        <div>
            <h1>Alterar Produto</h1>
            <form onSubmit={submeterForm}>
                <div>
                    <label>Nome: </label>    
                    <input value={nome} type="text" onChange={ (e : any) =>setNome(e.target.value)}required/>
                </div>
                <div>
                    <label>Preço: </label>
                    <input value={preco} type="text" onChange={(e : any) =>setPreco(e.target.value)} required/>
                </div>
                <div>
                    <label>Quantidade: </label>
                    <input value={quantidade} type="text" onChange={(e : any) =>setQuantidade(e.target.value)} required/>
                </div>
                <div>
                    <button type="submit">Salvar</button>
                </div>
            </form>
        </div>
    );

}

export default AlterarProduto;