using API.Models;
using Microsoft.EntityFrameworkCore;

//Crasse que não representa o banco de dados . Obs: NAO representa(confia)

// diferente do JAVA o implements(herança) pode ser feito por ":".
// 1 - informar as tableas do banco
// 2 -  Conf String de conexão
public class AppDataContext : DbContext
{
    //Atributos que apresentam tabelas na db
    public DbSet<Produto> Produtos { get; set; }

    public DbSet <Categoria> Categorias { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=Ecommerce.db");
    }


}