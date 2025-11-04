using Gabriel.Models;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Programa Rodando");

// POST /api/folhadepagamento/cadastrar
app.MapPost("/api/folhadepagamento/cadastrar", ( FolhaPagamento novaFolhaDePagamento) =>
{
    
});

app.Run();
