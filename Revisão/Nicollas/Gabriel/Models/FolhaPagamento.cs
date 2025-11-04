using System;

namespace Gabriel.Models;

public class FolhaPagamento
{
    public int Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public string Cpf { get; set; } = String.Empty;
    public int Mes { get; set; }
    public int Ano { get; set; }
    public int HorasTrabalhadas { get; set; }
    public int ValorHora { get; set; }
}
