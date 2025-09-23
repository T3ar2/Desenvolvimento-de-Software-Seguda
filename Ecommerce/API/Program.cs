using System.Linq.Expressions;
using API.Models;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

//Funcionalidade - Requisições
// - URL/Endereço
// - Um método HTTP

Console.Clear();

//Lista de produtos Fakes
var produtos = new List<Produto>(){
    new Produto {Nome = "Laptop Gamer", Quantidade = 5, Preco = 7500.00},
    new Produto {Nome = "Mouse Sem Fio", Quantidade = 50, Preco = 120.50},
    new Produto {Nome = "Teclado Mecânico", Quantidade = 20, Preco = 450.00},
    new Produto {Nome = "Monitor Ultrawide", Quantidade = 10, Preco = 1800.00},
    new Produto {Nome = "Webcam HD", Quantidade = 35, Preco = 250.00},
    new Produto {Nome = "Headset com Microfone", Quantidade = 40, Preco = 300.00},
    new Produto {Nome = "SSD 1TB", Quantidade = 15, Preco = 550.00},
    new Produto {Nome = "Placa de Vídeo RTX", Quantidade = 8, Preco = 3200.00},
    new Produto {Nome = "Roteador Wi-Fi 6", Quantidade = 25, Preco = 600.00},
    new Produto {Nome = "Cabo HDMI 2.1", Quantidade = 100, Preco = 45.00}
};

//Funcionalidade - Requisições
// - URL/Caminho/Endereço
// - Um método HTTP

// Métodos HTTP:
// GET    - Recupera dados do servidor
// POST   - Enviar/cadastrar dados para criar um recurso
// PUT    - Atualiza um recurso existente
// DELETE - Remove um recurso
// PATCH  - Atualiza parcialmente um recurso
    
    // códigos de stats HTTP
// 101 Switching Protocols: O servidor está trocando de protocolo, conforme solicitado pelo cliente.

// 200 OK: A requisição foi bem-sucedida.

// 201 Created: A requisição foi bem-sucedida e um novo recurso foi criado como resultado.

// 202 Accepted: A requisição foi aceita para processamento, mas o processamento ainda não foi concluído.

// 204 No Content: A requisição foi bem-sucedida, mas não há conteúdo para ser enviado no corpo da resposta.

// 3xx - Códigos de redirecionamento
// 301 Moved Permanently: O recurso solicitado foi permanentemente movido para um novo URL.

// 302 Found: O recurso solicitado está temporariamente em um URL diferente.

// 304 Not Modified: O cliente pode usar uma versão em cache do recurso, pois ele não foi modificado desde a última requisição.

// 400 Bad Request: A requisição está incorreta ou mal-formada.

// 401 Unauthorized: A requisição requer autenticação do usuário.

// 403 Forbidden: O servidor entendeu a requisição, mas se recusa a autorizá-la.

// 404 Not Found: O recurso solicitado não foi encontrado no servidor.

// 405 Method Not Allowed: O método de requisição (por exemplo, GET, POST) não é permitido para o recurso.

// 408 Request Timeout: O servidor não recebeu uma requisição completa do cliente no tempo esperado.

// 500 Internal Server Error: O servidor encontrou uma condição inesperada que o impediu de atender a requisição.

// 501 Not Implemented: O servidor não suporta a funcionalidade necessária para atender à requisição.

// 503 Service Unavailable: O servidor não está pronto para lidar com a requisição, geralmente por estar sobrecarregado ou em manutenção.

// 504 Gateway Timeout: O servidor (atuando como um gateway ou proxy) não recebeu uma resposta a tempo de um servidor upstream.

app.MapGet("/", () => "API de Produtos");

//GET: /api/produto/listar
app.MapGet("/api/produto/listar", () =>
{
    // validar a lista de produto para saber se existe algo dentro
    // .Count e .Any podem ser utilizados nessa condição
    if (produtos.Count > 0) { return Results.Ok(produtos); }
return Results.NotFound("Lista sem nada mané"); 
});


//GET: /api/produto/buscar/nome_do_produto
app.MapGet("/api/produto/buscar/{nome}", (String nome) =>
{
    // Foreach
    // foreach (Produto produtoAchado in produtos)
    // {
    //     if (produtoAchado.Nome == nome)
    //     {
    //         //Achado
    //         return Results.Ok(produtoAchado);
    //     }
    // }
    //expressão Lambda
    Produto? resultado = produtos.FirstOrDefault(x => x.Nome == nome);
    if (resultado is null) { return Results.NotFound("Produto não encontrado"); }
    return Results.Ok(resultado);
    

});




//POST: /api/crodutos/cadastrar
app.MapPost("/api/produto/cadastrar", ([FromBody] Produto produto) =>
{
    // não permitir o cadastro de um produto com o mesmo nome

    foreach (Produto produtoCadastrado in produtos)
    {
        if (produtoCadastrado.Nome == produto.Nome)
        {
            //Não cadastrar
            return Results.Conflict("Existe um produto com o mesmo nome.");
        }
    }
    produtos.Add(produto);
    return Results.Created("", produto);
});







app.Run();
