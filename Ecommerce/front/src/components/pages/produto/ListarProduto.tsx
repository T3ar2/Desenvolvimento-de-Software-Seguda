// regras para a criação de um componente 
// 1 - ele deve ser uma funcao
// 2 - retorne apenas 1 elemento pai HTML
// 3 - exportar o componente poara que ele seja utilizado

import { useEffect, useState } from "react";
import Produto from "../../../models/Produto";
import { Link } from "react-router-dom";

function ListarProdutos(){

        //Estados / variaveis
        const[produtos, setProdutos] = useState<Produto[]>([]);

    //UseEffect utilizado para executar codigo no momento em que o componente e carregado no navegador
    useEffect(() =>{
        listarProdutosAPI();
    }, [])

        async function listarProdutosAPI(){

            //AXIOS - biblioteca para realizar requisicoes
            try{
                const resposta = await axios.get("http://localhost:5279/api/produto/listar");
                const dados =  resposta.data;
                setProdutos(dados);
            }catch(error){
                console.log("Erro: " + error)
            }
                
        }

        async function deletarProdutoAPI(id : string){
            try{
                const  resposta = await axios.delete(`http://localhost:5279/api/produto/deletar/${id}`)
                listarProdutosAPI();
                console.log(`${id} deletado com sucesso.`)
           }
            catch(error){
                console.log(error);
            }
        }

        function deletarProduto(id : string){
            deletarProduto(id);
        }  
        
    return (
        <div id="componente_listar_produtos">
            <h1>Listar Produtos</h1>
            <table>
                <thead>
                    <tr>
                        <th>#</th>
                        <th>Nome</th>
                        <th>Preço</th>
                        <th>Quantidade</th>
                        <th>Criado Em</th>
                        <th>Deletar</th>
                        <th>Alterar</th>
                    </tr>
                </thead>
                <tbody>
                    {produtos.map((produto)=> (
                        <tr key={produto.id}>
                            <td>{produto.id}</td>
                            <td>{produto.nome}</td>
                            <td>{produto.preco}</td>
                            <td>{produto.quantidade}</td>
                            <td>{produto.criadoEm}</td>
                            <td>
                                <button onClick={() => deletarProduto(produto.id!)} >
                                    Deletar
                                </button>
                            </td>
                            <td><Link to={`/produto/alterar/${produto.id}`}/>Alterar</td>
                        </tr>
                    ))}
                </tbody>
            </table>
        </div>
    ); 
}

export default ListarProdutos;