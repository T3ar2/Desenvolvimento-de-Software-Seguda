var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

//Funcionalidade - Requisições
// - URL/Endereço
// - Um método HTTP

app.MapGet("/", () => "Minha segunda API ._.");

app.MapGet("/endereco", () => "Funcionálidade 1337 ._.");

app.MapPost("/endereco", () => "Funcionálidade do Post 1337 ._. ._. ._.");

app.Run();
