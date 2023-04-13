using ApiPortalNoticias.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiPortalNoticias.Context;

public class BancoDbContext : DbContext
{
    public DbSet<Noticia> Noticias { get; set; }
    public DbSet<Autor> Autores { get; set; }


    //Inserir no appsettings.json
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder){
        optionsBuilder.UseSqlite(connectionString: "DataSource=app.db;Cache=Shared");
    }
}
