using System;

namespace API.Models;

public class Produto
{
    //Construtor
    public Produto()
    {
        Id = Guid.NewGuid().ToString();
        CriadoEm = DateTime.Now;
    }

    // Atributos, Propriedades ou Características

    public String Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public int Quantidade { get; set; }
    public double Preco { get; set; }
    public DateTime CriadoEm { get; set; }


}