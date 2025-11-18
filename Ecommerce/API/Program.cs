using System.Linq.Expressions;
using System.Net.Http.Headers;
using API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Infrastructure;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend",
        builder =>
        {
            builder.AllowAnyOrigin()
                   .AllowAnyMethod()
                   .AllowAnyHeader();
        });
});
builder.Services.AddDbContext<AppDataContext>();
var app = builder.Build();

// Aplicar o middleware CORS
app.UseCors("AllowFrontend");

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
app.MapGet("/api/produto/listar", ([FromServices]AppDataContext ctx) =>
{
    
    // validar a lista de produto para saber se existe algo dentro
    // .Count e .Any podem ser utilizados nessa condição
    if (ctx.Produtos.Any()) { return Results.Ok(ctx.Produtos.ToList()); }
    return Results.NotFound("Lista sem nada mané"); 
});


//GET: /api/produto/buscar/nome_do_produto
app.MapGet("/api/produto/buscar/{id}", ([FromServices]AppDataContext ctx, [FromRoute]String id) =>
{
    //expressão Lambda   
    Produto? resultado = ctx.Produtos.FirstOrDefault(x => x.Id == id);
    if (resultado is null) { return Results.NotFound("Produto não encontrado"); }
    return Results.Ok(resultado);

});




//POST: /api/crodutos/cadastrar
app.MapPost("/api/produto/cadastrar", ([FromServices]AppDataContext ctx, [FromBody] Produto produto) =>
{
    // não permitir o cadastro de um produto com o mesmo nome

    // foreach (Produto produtoCadastrado in produtos)
    // {
    //     if (produtoCadastrado.Nome == produto.Nome)
    //     {
    //         //Não cadastrar
    //         return Results.Conflict("Existe um produto com o mesmo nome.");
    //     }
    // }
    // !: Melhor opcao
    Produto? resultado = ctx.Produtos.FirstOrDefault(x => x.Nome == produto.Nome);
    if (resultado is null)
    { 
        ctx.Produtos.Add(produto);
        ctx.SaveChanges();
        return Results.Created("", produto);
    }
    return Results.Conflict("Existe um produto com o mesmo nome.");

});


//DELETE : /api/produto/deletar/{id}
app.MapDelete("/api/produto/deletar/{id}", ([FromServices]AppDataContext ctx, [FromRoute] String id) =>
{ 
    Produto? resultado = ctx.Produtos.Find(id);
    if (resultado is null) { return Results.NotFound("Não é possível deletar algo em que não está no banco de dados."); }
    ctx.Produtos.Remove(resultado);
    ctx.SaveChanges();
    return Results.Ok(resultado + " deletado com sucesso.");

});


//UPDATE: /api/produto/alterar/{id}
app.MapPatch("/api/produto/alterar/{id}", ([FromServices]AppDataContext ctx, [FromRoute] String id, [FromBody] Produto produtoAlterada) => { 
    Produto? resultado = ctx.Produtos.Find(id);
    if (resultado is null) { return Results.NotFound("Produto não encontrado"); }
    resultado.Nome = produtoAlterada.Nome;
    resultado.Quantidade = produtoAlterada.Quantidade;
    resultado.Preco = produtoAlterada.Preco;
    ctx.Produtos.Update(resultado);
    ctx.SaveChanges();
    return Results.Ok(resultado + " alterado com sucesso. ");
});


AppDataContext ctx = new AppDataContext();
// ctx.Produtos

app.Run();
